var indexVue = new Vue({
    el: "#index",
    name: "indexbtns",
    data: {
        isAdmin: false,
        isUser: false,
    },
    methods: {
        checkClaims: async function () {
            const token = sessionStorage.getItem("token");

            if (token !== null) {
                this.isAdmin = hasUserAdminRole();
                this.isUser = !this.isAdmin;
            }
        },
        resetData: function () {
            this.isAdmin = false;
            this.isUser = false;
        },
    }
});