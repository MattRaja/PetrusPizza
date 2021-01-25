// import { AppState } from './state/app-state';
// import { autoinject, PLATFORM } from 'aurelia-framework';
// import { RouterConfiguration, Router } from 'aurelia-router';

// @autoinject
// export class App {
//     router?: Router;

//     constructor(private appState: AppState) {

//     }

//     configureRouter(config: RouterConfiguration, router: Router): void {
//         this.router = router;

//         config.title = "Pizza";

//         config.map([
//             { route: ['', 'home', 'home/index'], name: 'home', moduleId: PLATFORM.moduleName('views/home/index'), nav: true, title: 'Home' },

//             { route: ['account/login'], name: 'account-login', moduleId: PLATFORM.moduleName('views/account/login'), nav: false, title: 'Login' },
//             { route: ['account/register'], name: 'account-register', moduleId: PLATFORM.moduleName('views/account/register'), nav: false, title: 'Register' },


//             /*{ route: ['balances', 'balances/index'], name: 'balances-index', moduleId: PLATFORM.moduleName('views/balances/index'), nav: true, title: 'Balances' },
//             { route: ['balances/details/:id?'], name: 'balances-details', moduleId: PLATFORM.moduleName('views/balances/details'), nav: false, title: 'Balances Details' },
//             { route: ['balances/edit/:id?'], name: 'balances-edit', moduleId: PLATFORM.moduleName('views/balances/edit'), nav: false, title: 'Balances Edit' },
//             { route: ['balances/delete/:id?'], name: 'balances-delete', moduleId: PLATFORM.moduleName('views/balances/delete'), nav: false, title: 'Balances Delete' },
//             { route: ['balances/create'], name: 'balances-create', moduleId: PLATFORM.moduleName('views/balances/create'), nav: false, title: 'Balances Create' },

//             { route: ['extra-toppings-on-items', 'extra-toppings-on-items/index'], name: 'extra-toppings-on-items-index', moduleId: PLATFORM.moduleName('views/extra-toppings-on-items/index'), nav: true, title: 'Extra Toppings On Items' },
//             { route: ['extra-toppings-on-items/details/:id?'], name: 'extra-toppings-on-items-details', moduleId: PLATFORM.moduleName('views/extra-toppings-on-items/details'), nav: false, title: 'Extra Toppings On Items Details' },
//             { route: ['extra-toppings-on-items/edit/:id?'], name: 'extra-toppings-on-items-edit', moduleId: PLATFORM.moduleName('views/extra-toppings-on-items/edit'), nav: false, title: 'Extra Toppings On Items Edit' },
//             { route: ['extra-toppings-on-items/delete/:id?'], name: 'extra-toppings-on-items-delete', moduleId: PLATFORM.moduleName('views/extra-toppings-on-items/delete'), nav: false, title: 'Extra Toppings On Items Delete' },
//             { route: ['extra-toppings-on-items/create'], name: 'extra-toppings-on-items-create', moduleId: PLATFORM.moduleName('views/extra-toppings-on-items/create'), nav: false, title: 'Extra Toppings On Items Create' },

//             { route: ['item-rows', 'item-rows/index'], name: 'item-rows-index', moduleId: PLATFORM.moduleName('views/item-rows/index'), nav: true, title: 'Item Rows' },
//             { route: ['item-rows/details/:id?'], name: 'item-rows-details', moduleId: PLATFORM.moduleName('views/item-rows/details'), nav: false, title: 'Item Rows Details' },
//             { route: ['item-rows/edit/:id?'], name: 'item-rows-edit', moduleId: PLATFORM.moduleName('views/item-rows/edit'), nav: false, title: 'Item Rows Edit' },
//             { route: ['item-rows/delete/:id?'], name: 'item-rows-delete', moduleId: PLATFORM.moduleName('views/item-rows/delete'), nav: false, title: 'Item Rows Delete' },
//             { route: ['item-rows/create'], name: 'item-rows-create', moduleId: PLATFORM.moduleName('views/item-rows/create'), nav: false, title: 'Item Rows Create' },

//             { route: ['orders', 'orders/index'], name: 'orders-index', moduleId: PLATFORM.moduleName('views/orders/index'), nav: true, title: 'Orders' },
//             { route: ['orders/details/:id?'], name: 'orders-details', moduleId: PLATFORM.moduleName('views/orders/details'), nav: false, title: 'Orders Details' },
//             { route: ['orders/edit/:id?'], name: 'orders-edit', moduleId: PLATFORM.moduleName('views/orders/edit'), nav: false, title: 'Orders Edit' },
//             { route: ['orders/delete/:id?'], name: 'orders-delete', moduleId: PLATFORM.moduleName('views/orders/delete'), nav: false, title: 'Orders Delete' },
//             { route: ['orders/create'], name: 'orders-create', moduleId: PLATFORM.moduleName('views/orders/create'), nav: false, title: 'Orders Create' },

//             { route: ['order-rows', 'order-rows/index'], name: 'order-rows-index', moduleId: PLATFORM.moduleName('views/order-rows/index'), nav: true, title: 'Order Rows' },
//             { route: ['order-rows/details/:id?'], name: 'order-rows-details', moduleId: PLATFORM.moduleName('views/order-rows/details'), nav: false, title: 'Order Rows Details' },
//             { route: ['order-rows/edit/:id?'], name: 'order-rows-edit', moduleId: PLATFORM.moduleName('views/order-rows/edit'), nav: false, title: 'Order Rows Edit' },
//             { route: ['order-rows/delete/:id?'], name: 'order-rows-delete', moduleId: PLATFORM.moduleName('views/order-rows/delete'), nav: false, title: 'Order Rows Delete' },
//             { route: ['order-rows/create'], name: 'order-rows-create', moduleId: PLATFORM.moduleName('views/order-rows/create'), nav: false, title: 'Order Rows Create' },
//             */
//             { route: ['payments', 'payments/index'], name: 'payments-index', moduleId: PLATFORM.moduleName('views/payments/index'), nav: true, title: 'Payments' },
//             { route: ['payments/details/:id?'], name: 'payments-details', moduleId: PLATFORM.moduleName('views/payments/details'), nav: false, title: 'Payments Details' },
//             { route: ['payments/edit/:id?'], name: 'payments-edit', moduleId: PLATFORM.moduleName('views/payments/edit'), nav: false, title: 'Payments Edit' },
//             { route: ['payments/delete/:id?'], name: 'payments-delete', moduleId: PLATFORM.moduleName('views/payments/delete'), nav: false, title: 'Payments Delete' },
//             { route: ['payments/create'], name: 'payments-create', moduleId: PLATFORM.moduleName('views/payments/create'), nav: false, title: 'Payments Create' },
// /*
//             { route: ['payment-methods', 'payment-methods/index'], name: 'payment-methods-index', moduleId: PLATFORM.moduleName('views/payment-methods/index'), nav: true, title: 'Payment Methods' },
//             { route: ['payment-methods/details/:id?'], name: 'payment-methods-details', moduleId: PLATFORM.moduleName('views/payment-methods/details'), nav: false, title: 'Payment Methods Details' },
//             { route: ['payment-methods/edit/:id?'], name: 'payment-methods-edit', moduleId: PLATFORM.moduleName('views/payment-methods/edit'), nav: false, title: 'Payment Methods Edit' },
//             { route: ['payment-methods/delete/:id?'], name: 'payment-methods-delete', moduleId: PLATFORM.moduleName('views/payment-methods/delete'), nav: false, title: 'Payment Methods Delete' },
//             { route: ['payment-methods/create'], name: 'payment-methods-create', moduleId: PLATFORM.moduleName('views/payment-methods/create'), nav: false, title: 'Payment Methods Create' },
// */
//             { route: ['persons', 'persons/index'], name: 'persons-index', moduleId: PLATFORM.moduleName('views/persons/index'), nav: true, title: 'Persons' },
//             { route: ['persons/details/:id?'], name: 'persons-details', moduleId: PLATFORM.moduleName('views/persons/details'), nav: false, title: 'Persons Details' },
//             { route: ['persons/edit/:id?'], name: 'persons-edit', moduleId: PLATFORM.moduleName('views/persons/edit'), nav: false, title: 'Persons Edit' },
//             { route: ['persons/delete/:id?'], name: 'persons-delete', moduleId: PLATFORM.moduleName('views/persons/delete'), nav: false, title: 'Persons Delete' },
//             { route: ['persons/create'], name: 'persons-create', moduleId: PLATFORM.moduleName('views/persons/create'), nav: false, title: 'Persons Create' },

//             { route: ['pizza-names', 'pizza-names/index'], name: 'pizza-names-index', moduleId: PLATFORM.moduleName('views/pizza-names/index'), nav: true, title: 'Pizza Names' },
//             { route: ['pizza-names/details/:id?'], name: 'pizza-names-details', moduleId: PLATFORM.moduleName('views/pizza-names/details'), nav: false, title: 'Pizza Names Details' },
//             { route: ['pizza-names/edit/:id?'], name: 'pizza-names-edit', moduleId: PLATFORM.moduleName('views/pizza-names/edit'), nav: false, title: 'Pizza Names Edit' },
//             { route: ['pizza-names/delete/:id?'], name: 'pizza-names-delete', moduleId: PLATFORM.moduleName('views/pizza-names/delete'), nav: false, title: 'Pizza Names Delete' },
//             { route: ['pizza-names/create'], name: 'pizza-names-create', moduleId: PLATFORM.moduleName('views/pizza-names/create'), nav: false, title: 'Pizza Names Create' },
// /*
//             { route: ['pizza-orders', 'pizza-orders/index'], name: 'pizza-orders-index', moduleId: PLATFORM.moduleName('views/pizza-orders/index'), nav: true, title: 'Pizza Orders' },
//             { route: ['pizza-orders/details/:id?'], name: 'pizza-orders-details', moduleId: PLATFORM.moduleName('views/pizza-orders/details'), nav: false, title: 'Pizza Orders Details' },
//             { route: ['pizza-orders/edit/:id?'], name: 'pizza-orders-edit', moduleId: PLATFORM.moduleName('views/pizza-orders/edit'), nav: false, title: 'Pizza Orders Edit' },
//             { route: ['pizza-orders/delete/:id?'], name: 'pizza-orders-delete', moduleId: PLATFORM.moduleName('views/pizza-orders/delete'), nav: false, title: 'Pizza Orders Delete' },
//             { route: ['pizza-orders/create'], name: 'pizza-orders-create', moduleId: PLATFORM.moduleName('views/pizza-orders/create'), nav: false, title: 'Pizza Orders Create' },

//             { route: ['pizza-sizes', 'pizza-sizes/index'], name: 'pizza-sizes-index', moduleId: PLATFORM.moduleName('views/pizza-sizes/index'), nav: true, title: 'Pizza Sizes' },
//             { route: ['pizza-sizes/details/:id?'], name: 'pizza-sizes-details', moduleId: PLATFORM.moduleName('views/pizza-sizes/details'), nav: false, title: 'Pizza Sizes Details' },
//             { route: ['pizza-sizes/edit/:id?'], name: 'pizza-sizes-edit', moduleId: PLATFORM.moduleName('views/pizza-sizes/edit'), nav: false, title: 'Pizza Sizes Edit' },
//             { route: ['pizza-sizes/delete/:id?'], name: 'pizza-sizes-delete', moduleId: PLATFORM.moduleName('views/pizza-sizes/delete'), nav: false, title: 'Pizza Sizes Delete' },
//             { route: ['pizza-sizes/create'], name: 'pizza-sizes-create', moduleId: PLATFORM.moduleName('views/pizza-sizes/create'), nav: false, title: 'Pizza Sizes Create' },

//             { route: ['pizza-types', 'pizza-types/index'], name: 'pizza-types-index', moduleId: PLATFORM.moduleName('views/pizza-types/index'), nav: true, title: 'Pizza Types' },
//             { route: ['pizza-types/details/:id?'], name: 'pizza-types-details', moduleId: PLATFORM.moduleName('views/pizza-types/details'), nav: false, title: 'Pizza Types Details' },
//             { route: ['pizza-types/edit/:id?'], name: 'pizza-types-edit', moduleId: PLATFORM.moduleName('views/pizza-types/edit'), nav: false, title: 'Pizza Types Edit' },
//             { route: ['pizza-types/delete/:id?'], name: 'pizza-types-delete', moduleId: PLATFORM.moduleName('views/pizza-types/delete'), nav: false, title: 'Pizza Types Delete' },
//             { route: ['pizza-types/create'], name: 'pizza-types-create', moduleId: PLATFORM.moduleName('views/pizza-types/create'), nav: false, title: 'Pizza Types Create' },

//             { route: ['toppings', 'toppings/index'], name: 'toppings-index', moduleId: PLATFORM.moduleName('views/toppings/index'), nav: true, title: 'Toppings' },
//             { route: ['toppings/details/:id?'], name: 'toppings-details', moduleId: PLATFORM.moduleName('views/toppings/details'), nav: false, title: 'Toppings Details' },
//             { route: ['toppings/edit/:id?'], name: 'toppings-edit', moduleId: PLATFORM.moduleName('views/toppings/edit'), nav: false, title: 'Toppings Edit' },
//             { route: ['toppings/delete/:id?'], name: 'toppings-delete', moduleId: PLATFORM.moduleName('views/toppings/delete'), nav: false, title: 'Toppings Delete' },
//             { route: ['toppings/create'], name: 'toppings-create', moduleId: PLATFORM.moduleName('views/toppings/create'), nav: false, title: 'Toppings Create' },
// */
//           ]
//         );

//         config.mapUnknownRoutes('views/home/index');
//     }

//     logoutOnClick(){
//         this.appState.jwt = null;
//         this.router!.navigateToRoute('account-login');
//     }

// }
