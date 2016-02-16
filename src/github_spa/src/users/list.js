import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {Router} from 'aurelia-router'
import 'fetch';

@inject(HttpClient, Router)
export class Users {
  heading = 'Github Users';
  users = [];

  goToUserDetails(username) {
      this.router.navigateToRoute("UserDetail", {"username": username});
  }

  constructor(http, router) {
    http.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl('http://localhost:9000/api/');
    });

    this.http = http;
    this.router = router;
  }

  activate() {
    return this.http.fetch('users')
      .then(response => response.json())
      .then(users => this.users = users);
  }
}
