import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class Users {
    heading = 'Github Users' ;
    users = [];
    searchTerm = "" ;

    constructor(http) {
        http.configure(config => {
            config
                .useStandardConfiguration()
                .withBaseUrl('http://localhost:9000/api/');
        });

        this.http = http;
        this.vm = this;
    }
    activate() {
    }

    completeSearch = () => {
        console.log(this);
        console.log("Complete searh triggered");
        this.http.fetch('search/users/' + this.searchTerm)
            .then(response => response.json())
            .then(users => this.users = users.items);

        console.log(this.users);
    }
}
