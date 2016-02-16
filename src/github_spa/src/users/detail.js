import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class UserDetail {
    heading = 'Github Users';

    constructor(http) {
        http.configure(config => {
            config
              .useStandardConfiguration()
              .withBaseUrl('http://localhost:9000/api/');
        });

        this.http = http;
    }

    activate(params) {
        console.log(params.username);
        return this.http.fetch('users/' + params.username)
          .then(response => response.json())
          .then(user => this.user = user);
    }
}