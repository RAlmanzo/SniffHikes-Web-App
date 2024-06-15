var adminVue = new Vue({
    el: "#admin",
    name: "crud",
    data: {
        events: [],
        routes: [],
        eventsUrl: "https://localhost:7038/api/Admins/events",
        routesUrl: "https://localhost:7038/api/Admins/routes",
        adminEventsVisible: false,
        adminRoutesVisible: false,
        isAdmin: false,
        isLogged: false,
        isUser: false,
        eventDetails: null,
        showEventDetailsSection: false,
        showDetails: false,
    },
    created: function () {

    },
    methods: {
        getEvents: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.isAdmin = hasUserAdminRole();
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
        showAdminEvents: async function () {
            if (this.events.length <= 0) {
                this.getEvents();
            }
            
            this.showEventDetailsSection = false;
            this.adminEventsVisible = true;
            this.adminRoutesVisible = false;
            this.showDetails = false;
        },
        showAdminRoutes: async function () {
            if (this.routes.length <= 0) {
                this.getRoutes();
            }
      
            this.adminRoutesVisible = true;
            this.adminEventsVisible = false;
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
