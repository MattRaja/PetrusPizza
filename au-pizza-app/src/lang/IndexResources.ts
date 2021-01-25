export interface IIndexResourceStrings {
    sessions: string;
}
export interface IIndexResources {
    'en-GB': IIndexResourceStrings;
    'et-EE': IIndexResourceStrings;
}
export const IndexResources: IIndexResources = {
    'en-GB':{
        sessions: 'GPS Sessions',
    },
    'et-EE': {
        sessions: 'Treeningud',
    }
}
