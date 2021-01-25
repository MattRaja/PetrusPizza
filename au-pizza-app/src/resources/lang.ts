import { autoinject } from 'aurelia-framework';
import { AppState } from "state/app-state";

interface ILangStrings {
    name: string;
    description: string;
    language: string;
    login: string;
    logout: string;
    register: string;
    edit: string;
    save: string;
    delete: string;
    backToList: string;
    showHideFilter: string;
}

interface ILangResources {
    'en-GB': ILangStrings;
    'et-EE': ILangStrings;
    [propName: string]: ILangStrings;
}

const LangResources: ILangResources = {
    'en-GB': {
        name: 'Name',
        description: 'Description',
        language: 'Language',
        login: 'Login',
        logout: 'Logout',
        register: 'Register',
        edit: 'Edit',
        save: 'Save',
        delete: 'Delete',
        backToList: 'Back to List',
        showHideFilter: 'Show/hide filter',
    },
    'et-EE': {
        name: 'Nimi',
        description: 'Kirjeldus',
        language: 'Keel',
        login: 'Logi sisse',
        logout: 'Logi välja',
        register: 'Registreeri',
        edit: 'Muuda',
        save: 'Salvesta',
        delete: 'Kustuta',
        backToList: 'Tagasi nimekirja',
        showHideFilter: 'Näita/peida filter',
    }
}

@autoinject
export default class LangStrings {
    /*
    selected: ILangStrings;
    constructor(private appState: AppState) {
        this.selected = LangResources[this.appState.culture?.code || 'en-GB'];
    }

    setLang(lang = 'en-GB'): void {
        this.selected = LangResources[lang];
    }
    */
}
