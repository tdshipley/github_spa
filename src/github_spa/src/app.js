export class App {
  configureRouter(config, router) {
    config.title = 'Aurelia';
    config.map([
      { route: ['', 'welcome'],   name: 'welcome',      moduleId: 'welcome',      nav: true, title: 'Welcome' },
      { route: 'users',           name: 'Users',        moduleId: 'users/list',   nav: true, title: 'Github Users' },
      { route: 'users/:username', name: 'UserDetail',   moduleId: 'users/detail' },
      { route: 'users/search',    name: 'UserSearch',   moduleId: 'users/search', nav: true, title: 'Github User Search' }
    ]);

    this.router = router;
  }
}
