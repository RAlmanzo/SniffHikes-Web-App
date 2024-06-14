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
        showAdminEvents: async function () {
            this.getEvents();
            this.adminEventsVisible = true;
            this.adminRoutesVisible = false;
        },
        showAdminRoutes: async function () {
            this.getRoutes();
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
