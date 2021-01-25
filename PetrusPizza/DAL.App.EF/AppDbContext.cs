using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IBaseEntityTracker
    {
        private IUserNameProvider _userNameProvider;
        public DbSet<Balance> Balances { get; set; } = default!;
        public DbSet<DefaultTopping> DefaultToppings { get; set; } = default!;
        public DbSet<ExtraToppingsOnItem> ExtraToppingsOnItems { get; set; } = default!;
        public DbSet<ItemRow> ItemRows { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderRow> OrderRows { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        //public DbSet<PaymentMethod> PaymentMethods { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<PizzaName> PizzaNames { get; set; } = default!;
        public DbSet<PizzaOrder> PizzaOrders { get; set; } = default!;
        public DbSet<PizzaSize> PizzaSizes { get; set; } = default!;
        public DbSet<PizzaType> PizzaTypes { get; set; } = default!;
        public DbSet<Topping> Toppings { get; set; } = default!;
        public DbSet<LangStr> LangStrs { get; set; } = default!;
        public DbSet<LangStrTranslation> LangStrTranslation { get; set; } = default!;
        private readonly Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>> _entityTracker =
            new Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>>();

        
        public AppDbContext(DbContextOptions<AppDbContext> options, IUserNameProvider userNameProvider)
            : base(options)
        {
            _userNameProvider = userNameProvider;
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model
                .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            builder.Entity<LangStr>()
                .HasMany(s => s.Translations)
                .WithOne(l => l.LangStr!)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private void SaveChangesMetadataUpdate()
        {
            // update the state of ef tracked objects
            ChangeTracker.DetectChanges();
            
            var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entityEntry in markedAsAdded)
            {
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;
                entityWithMetaData.CreatedAt = DateTime.Now;
                entityWithMetaData.CreatedBy = _userNameProvider.CurrentUserName;
                entityWithMetaData.ChangedAt = entityWithMetaData.CreatedAt;
                entityWithMetaData.ChangedBy = entityWithMetaData.CreatedBy;
            }

            var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entityEntry in markedAsModified)
            {
                // check for IDomainEntityMetadata
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;

                entityWithMetaData.ChangedAt = DateTime.Now;
                entityWithMetaData.ChangedBy = _userNameProvider.CurrentUserName;

                // do not let changes on these properties get into generated db sentences - db keeps old values
                entityEntry.Property(nameof(entityWithMetaData.CreatedAt)).IsModified = false;
                entityEntry.Property(nameof(entityWithMetaData.CreatedBy)).IsModified = false;
            }
        }

        private void UpdateTrackedEntities()
        {
            foreach (var (key, value) in _entityTracker)
            {
                value.Id = key.Id;
            }
        }

        public override int SaveChanges()
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChanges();
            UpdateTrackedEntities();
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChangesAsync(cancellationToken);
            UpdateTrackedEntities();
            return result;
        }


        public void AddToEntityTracker(IDomainEntityId internalEntity, IDomainEntityId externalEntity)
        {
            _entityTracker.Add(internalEntity, externalEntity);
        }

        public void AddToEntityTracker(IDomainEntityId<Guid> internalEntity, IDomainEntityId<Guid> externalEntity)
        {
            _entityTracker.Add(internalEntity, externalEntity);
        }

        public void RemoveFromEntityTracker(IDomainEntityId<Guid> internalEntity)
        {
            _entityTracker.Remove(internalEntity);
        }
    }
}