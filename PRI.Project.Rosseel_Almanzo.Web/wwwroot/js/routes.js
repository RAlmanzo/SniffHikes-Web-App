var routesVue = new Vue({
    el: "#routes",
    name: "userRoutes",
    data: {
        routes: [],
        routesUrl: "https://localhost:7038/api/Routes",
        adminRoutesVisible: false,
        routeDetails: null,
        showRouteDetailsSection: false,
        showDetails: false,
        organizer: "",
        organizerId: "",
        id: "",
        title: "",
        description: "",
        address: {
            street: "",
            city: "",
            state: "",
            country: "",
        },
        images: [],
        createErrors: {
            Title: [],
            Description: [],
            DateEvent: [],
            Price: [],
            Address: {
                Street: [],
                City: [],
                State: [],
                Country: [],
            },
        },
        isUser: false,
        isOrganizer: false,
        userId: "",
    },
    created: function () {
        this.checkClaims();
        this.getRoutes();
    },
    methods: {
        showUpdateRouteModal: async function (id) {
            const url = `https://localhost:7038/api/Routes/${id}`

            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.id = response.data.id;
                    this.title = response.data.value;
                    this.description = response.data.description;
                    this.address.street = response.data.address.street;
                    this.address.city = response.data.address.city;
                    this.address.state = response.data.address.state;
                    this.address.country = response.data.address.country;
                    this.organizerId = response.data.orginazer.id;
                })
                .catch((e) => {
                    //this.showErrorSection = true;
                    //this.errorMessage = e.message
                })

            this.toggleModal("updateRouteModal");
        },
        updateRoute: async function () {

            //set the data
            data = {
                "id": this.id,
                "title": this.title,
                "description": this.description,
                "address": {
                    street: this.address.street,
                    city: this.address.city,
                    state: this.address.state,
                    country: this.address.country
                },
                "organizerId": this.organizerId,
            }

            //config headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            //call the api
            await axios.put(this.routesUrl, data, config)
                .then(response => {
                    console.log(response);
                    this.toggleModal("updateRouteModal");
                    this.getRoutes();
                })
                .catch(error => {
                    if (error.response && error.response.data.errors) {
                        this.setErrors(error.response.data.errors);
                    } else {
                        //this.error = true;
                        //this.errorMessage = { general: ["An unexpected error occurred."] };
                    }
                });
        },
        createRoute: async function () {
            this.clearErrors();
            this.routeDetails = null;
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.organizerId = readUserIdFromToken();

                const formData = new FormData();
                formData.append("Title", this.title);
                formData.append("Description", this.description);
                formData.append("Address.Street", this.address.street);
                formData.append("Address.City", this.address.city);
                formData.append("Address.State", this.address.state);
                formData.append("Address.Country", this.address.country);
                formData.append("OrganizerId", this.organizerId);

                for (let i = 0; i < this.images.length; i++) {
                    formData.append("Images", this.images[i]);
                }

                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };

                await axios.post(this.routesUrl, formData, config, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                })
                    .then(response => {
                        console.log(response);
                        this.toggleModal("crudRouteModal");
                        this.resetForm();
                        this.getRoutes();
                    })
                    .catch(error => {
                        if (error.response && error.response.data.errors) {
                            this.setErrors(error.response.data.errors);
                        } else {
                            //this.error = true;
                            //this.errorMessage = { general: ["An unexpected error occurred."] };
                        }
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
        showRouteDetails: async function (id) {
            const url = `https://localhost:7038/api/Routes/${id}`
            //set the headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.routeDetails = response.data;
                    this.organizer = response.data.orginazer.value;
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
            if (confirm("Are u sure u want to delete Route?")) {
                const url = `https://localhost:7038/api/Routes/${id}`
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
                        this.routes = this.routes.filter(el => el.id !== id);
                    })
                    .catch(error => {
                        console.log(error);
                    });
            };
        },
        showRoutes: async function () {
            if (this.routes.length <= 0) {
                this.getRoutes();
            }

            this.showRouteDetailsSection = false;
            this.adminRoutesVisible = true;
            this.showDetails = false;
        },
        toggleModal: function (modalId) {
            if (modalId === "crudRouteModal") {
                this.resetForm();
            }

            $(`#${modalId}`).modal('toggle');
        },
        getFile: function (event) {
            //put the file in the image
            this.images = event.target.files;
        },
        setErrors(errors) {
            for (const key in errors) {
                if (this.createErrors.hasOwnProperty(key)) {
                    this.createErrors[key] = errors[key];
                }
                else if (key.startsWith("Address.")) {
                    const addressKey = key.split('.')[1];
                    if (this.createErrors.Address.hasOwnProperty(addressKey)) {
                        this.createErrors.Address[addressKey] = errors[key];
                    }
                }
            }
        },
        clearErrors: function () {
            /*this.error = false;*/
            this.registerErrors = {
                Title: [],
                Description: [],
                Address: {
                    Street: [],
                    City: [],
                    State: [],
                    Country: [],
                },
            };
        },
        resetForm() {
            this.title = "";
            this.description = "";
            this.address.street = "";
            this.address.city = "";
            this.address.state = "";
            this.address.country = "";
            this.images = [];
            this.organizerId = "";
        },

        checkClaims: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.isUser = hasUserRole();
                this.isOrganizer = hasOrganizerRole();

                this.userId = readUserIdFromToken();
            }
        },
    }
});