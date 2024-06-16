var eventsVue = new Vue({
    el: "#events",
    name: "userEvents",
    data: {
        events: [],
        eventsUrl: "https://localhost:7038/api/Events",
        adminEventsVisible: false,
        eventDetails: null,
        showEventDetailsSection: false,
        showDetails: false,
        organizerId: "",
        id: "",
        title: "",
        description: "",
        date: "",
        price: "",
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
    },
    created: function () {
        this.getEvents();
    },
    methods: {
        showUpdateEventModal: async function (id) {
            const url = `https://localhost:7038/api/Events/${id}`

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
                    this.price = response.data.price;
                    this.date = response.data.date;
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

            this.toggleModal("updateEventModal");
        },
        updateEvent: async function () {

            //set the data
            data = {
                "id": this.id,
                "title": this.title,
                "description": this.description,
                "date": this.date,
                "price": this.price,
                "address": {
                    street: this.address.street,
                    city: this.address.city,
                    state: this.address.state,
                    country: this.address.country
                },
                "organizerId": this.organizerId,
            }

            var token = sessionStorage.getItem("token");
            //config headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            //call the api
            await axios.put(this.eventsUrl, data, config)
                .then(response => {
                    console.log(response);
                    this.toggleModal("updateEventModal");
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
        createEvent: async function () {
            this.clearErrors();
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.organizerId = readUserIdFromToken();

                const formData = new FormData();
                formData.append("Title", this.title);
                formData.append("Description", this.description);
                formData.append("Date", this.date);
                formData.append("Price", this.price);
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

                await axios.post(this.eventsUrl, formData, config, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                })
                    .then(response => {
                        // Handle successful registration
                        this.resetForm();
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
        getEvents: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
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
            const url = `https://localhost:7038/api/Events/${id}`
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
        showEvents: async function () {
            if (this.events.length <= 0) {
                this.getEvents();
            }

            this.showEventDetailsSection = false;
            this.adminEventsVisible = true;
            this.showDetails = false;
        },
        toggleModal: function (modalId) {
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
                DateEvent: [],
                Price: [],
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
            this.dateEvent = "";
            this.price = "";
            this.address.street = "";
            this.address.city = "";
            this.address.state = "";
            this.address.country = "";
            this.images = [];
            this.organizerId = "";
        },
    }
});