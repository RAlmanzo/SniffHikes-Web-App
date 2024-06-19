var profileVue = new Vue({
    el: "#profile",
    name: "userProfile",
    data: {
        userUrl: "https://localhost:7038/api/Users",
        isUser: false,
        isOrganizer: false,
        userId: "",
        id: "",
        firstName: "",
        lastName: "",
        dateOfBirth: "",
        gender: "",
        email: "",
        address: {
            street: "",
            city: "",
            state: "",
            country: "",
        },
        image: "",
        showUserDetailsSection: false,
        userDetails: null,
        registerErrors: {
            FirstName: [],
            LastName: [],
            DateOfBirth: [],
            Email: [],
            Address: {
                Street: [],
                City: [],
                State: [],
                Country: [],
            },
        },
        dogs: [],
        dogName: "",
        dogDateOfBirth: "",
        dogGender: "",
        dogRace: "",
        dogImage: "",
        createDogErrors: {
            Name: [],
            DateOfBirth: [],
        },
    },
    created: function () {
        this.checkClaims();
        this.getUser();
    },
    methods: {
        addDog: async function () {
            if (!this.dogImage) {
                alert("Please select an image to upload.");
                return;
            }

            const formData = new FormData();
            formData.append("Name", this.dogName);
            formData.append("DateOfBirth", this.dogDateOfBirth);
            formData.append("Gender", this.dogGender);
            formData.append("Race", this.dogRace);
            formData.append("Image", this.dogImage);

            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            const url = `https://localhost:7038/api/Users/${this.userId}/dog`

            await axios.post(url, formData, config,{
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            })
                .then(response => {
                    this.dogs = response.data.dogs;                  
                    this.toggleModal("createDogModal");
                    this.toggleModal("updateUserModal");
                    this.resetdogForm();
                    this.clearDogErrors();
                })
                .catch(error => {
                    if (error.response && error.response.data.errors) {
                        this.setDogErrors(error.response.data.errors);
                    } else {
                        this.error = true;
                        this.errorMessage = { general: ["An unexpected error occurred."] };
                    }
                });
        },
        deleteDog: async function (id) {
            if (confirm("Are u sure u want to delete Dog?")) {
                const url = `https://localhost:7038/api/Users/${id}/dog`
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
                        this.dogs = this.dogs.filter(el => el.id !== id);
                    })
                    .catch(error => {
                        console.log(error);
                    });
            };
        },
        getUser: async function () {
            const url = `https://localhost:7038/api/Users/${this.userId}`
            //set the headers => token
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.userDetails = response.data;
                    this.showUserDetailsSection = true;
                })
                .catch((e) => {
                    //this.showErrorSection = true;
                    //this.errorMessage = e.message
                })
        },
        showUpdateUserModal: async function () {
            this.clearErrors();
            const url = `https://localhost:7038/api/Users/${this.userId}`

            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.get(url, config)
                .then((response) => {
                    this.id = response.data.id;
                    this.firstName = response.data.firstName;
                    this.lastName = response.data.lastName;
                    this.dateOfBirth = response.data.dateOfBirth;
                    this.gender = response.data.gender;
                    this.email = response.data.email;
                    this.address.street = response.data.address.street;
                    this.address.city = response.data.address.city;
                    this.address.state = response.data.address.state;
                    this.address.country = response.data.address.country;
                    this.dogs = response.data.dogs;
                })
                .catch((e) => {
                    //this.showErrorSection = true;
                    //this.errorMessage = e.message
                })

            this.toggleModal("updateUserModal");
        },
        updateUser: async function () {
            const formData = new FormData();
            formData.append("Id", this.id);
            formData.append("FirstName", this.firstName);
            formData.append("LastName", this.lastName);
            formData.append("DateOfBirth", this.dateOfBirth);
            formData.append("Gender", this.gender);
            formData.append("Email", this.email);
            formData.append("Address.Street", this.address.street);
            formData.append("Address.City", this.address.city);
            formData.append("Address.State", this.address.state);
            formData.append("Address.Country", this.address.country);
            formData.append("Image", this.image);

            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };

            await axios.put(this.userUrl, formData, config)
                .then(response => {
                    console.log(response);
                    this.getUser();
                    this.clearErrors();
                    this.toggleModal("updateUserModal");
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
        deleteUser: async function () {
            //confirm delete
            if (confirm("Are u sure u want to delete User?")) {
                const url = `https://localhost:7038/api/Users/${this.userId}`
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
                        sessionStorage.clear();
                        this.isUser = false;
                        this.isOrganizer = false;
                        window.location.href = '/'; 
                    }).catch(error => console.log(error));
            };
        },
        clearErrors: function () {
            this.error = false;
            this.registerErrors = {
                Email: [],
                DateOfBirth: [],
                FirstName: [],
                LastName: [],
                Address: {
                    Street: [],
                    City: [],
                    State: [],
                    Country: [],
                },
            };
        },
        clearDogErrors: function () {
            this.error = false;
            this.createDogErrors = {
                Name: [],
                DateOfBirth: [],
            };
        },
        setErrors(errors) {
            this.clearErrors();

            for (const key in errors) {
                if (this.registerErrors.hasOwnProperty(key)) {
                    this.registerErrors[key] = errors[key];
                }
                else if (key.startsWith("Address.")) {
                    const addressKey = key.split('.')[1];
                    if (this.registerErrors.Address.hasOwnProperty(addressKey)) {
                        this.registerErrors.Address[addressKey] = errors[key];
                    }
                }
            }
        },
        setDogErrors(errors) {
            this.clearDogErrors();

            for (const key in errors) {
                if (this.createDogErrors.hasOwnProperty(key)) {
                    this.createDogErrors[key] = errors[key];
                }
            }
        },
        checkClaims: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.isUser = hasUserRole();
                this.isOrganizer = hasOrganizerRole();

                this.userId = readUserIdFromToken();
            }
        },
        toggleModal: function (modalId) {
            $(`#${modalId}`).modal('toggle');
        },
        getFile: function (event) {
            //put the file in the image
            this.image = event.target.files[0];
        },
        getDogFile: function (event) {
            //put the file in the image
            this.dogImage = event.target.files[0];
        },
        resetForm() {
            this.firstName = "";
            this.lastName = "";
            this.dateOfBirth = "";
            this.gender = "";
            this.email = "";
            this.address.street = "";
            this.address.city = "";
            this.address.state = "";
            this.address.country = "";
            this.image = "";
        },
        resetDogForm() {
            this.dogName = "";
            this.dogDateOfBirth = "";
            this.dogGender = "";
            this.dogRace = "";
            this.dogImage = "";
        },
    }
});