var adminVue = new Vue({
    el: "#admin",
    name: "crud",
    data: {
        events: [],
        routes: [],
        users: [],
        eventsUrl: "https://localhost:7038/api/Admins/events",
        routesUrl: "https://localhost:7038/api/Admins/routes",
        usersUrl: "https://localhost:7038/api/Admins/users",
        adminEventsVisible: false,
        adminRoutesVisible: false,
        adminUsersVisible: false,
        isAdmin: false,
        isLogged: false,
        isUser: false,
        eventDetails: null,
        routeDetails: null,
        showEventDetailsSection: false,
        showRouteDetailsSection: false,
        showDetails: false,
        image: "",
    },
    created: function () {
        this.isAdmin = hasUserAdminRole();
    },
    methods: {
        getEvents: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.image = readUserProfilePictureFromToken();
                this.isUser = !this.isAdmin;
                this.isLogged = true;

                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };

                this.events = await axios.get(this.eventsUrl, config)
                    .then(response => {
                        console.log(response.data.events);
                        return response.data.events;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        },
        showEventDetails: async function (id) {
            const url = `https://localhost:7038/api/Admins/${id}/event`
            //set the headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.eventDetails = response.data;
                    this.adminEventsVisible = false;
                    this.showEventDetailsSection = true;
                    this.showDetails = true;
                })
                .catch((e) => {
                    //this.showErrorSection = true;
                    //this.errorMessage = e.message
                })
        },
        deleteEvent: async function (id) {
            //confirm delete
            if (confirm("Are u sure u want to delete Event?")) {
                //build the url
                //const url = `${this.baseUrl}artists/${id}`;
                const url = `https://localhost:7038/api/Admins/${id}/event`
                //set the headers => token
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };
                //send the request
                await axios.delete(url, config)
                    .then(response => {
                        console.log(response.data);
                        //remove artist from list
                        this.events = this.events.filter(el => el.id !== id);
                    }).catch(error => console.log(error));
            };
        },
        getRoutes: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };

                this.routes = await axios.get(this.routesUrl, config)
                    .then(response => {
                        console.log(response.data.routes);
                        return response.data.routes;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        },
        showRouteDetails: async function (id) {
            const url = `https://localhost:7038/api/Admins/${id}/route`
            //set the headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.routeDetails = response.data;
                    this.adminRoutesVisible = false;
                    this.showRouteDetailsSection = true;
                    this.showDetails = true;
                })
                .catch((e) => {
                    //this.showErrorSection = true;
                    //this.errorMessage = e.message
                })
        },
        deleteRoute: async function (id) {
            //confirm delete
            if (confirm("Are u sure u want to delete Route?")) {
                //build the url
                //const url = `${this.baseUrl}artists/${id}`;
                const url = `https://localhost:7038/api/Admins/${id}/route`
                //set the headers => token
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };
                //send the request
                await axios.delete(url, config)
                    .then(response => {
                        console.log(response.data);
                        //remove artist from list
                        this.routes = this.routes.filter(el => el.id !== id);
                    }).catch(error => console.log(error));
            };
        },
        getUsers: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };

                this.users = await axios.get(this.usersUrl, config)
                    .then(response => {
                        console.log(response.data.users);
                        return response.data.users;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        },
        showAdminEvents: async function () {
            if (this.events.length <= 0) {
                this.getEvents();
            }
            
            this.showEventDetailsSection = false;
            this.adminEventsVisible = true;
            this.adminRoutesVisible = false;
            this.adminUsersVisible = false;
            this.showDetails = false;
        },
        showAdminRoutes: async function () {
            if (this.routes.length <= 0) {
                this.getRoutes();
            }

            this.showRouteDetailsSection = false;
            this.adminRoutesVisible = true;
            this.adminEventsVisible = false;
            this.adminUsersVisible = false;
            this.showDetails = false;
        },
        showAdminUsers: async function () {
            if (this.routes.length <= 0) {
                this.getUsers();
            }

            this.showUserDetailsSection = false;
            this.adminUsersVisible = true;
            this.adminRoutesVisible = false;
            this.adminEventsVisible = false;
            this.showDetails = false;
        },
        toggleModal: function (modalId) {
            $(`#${modalId}`).modal('toggle');
        },
        resetData: function () {
            this.events = [];
            this.routes = [];
            this.adminEventsVisible = false;
            this.adminRoutesVisible = false;
            this.isAdmin = false;
            this.isLogged = false;
            this.isUser = false;
        },
    }
});
