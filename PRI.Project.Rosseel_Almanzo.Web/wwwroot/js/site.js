// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const baseUrl = "https://localhost:7086/api/";

//Keys of ClaimTypes
const roleClaimTypeKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
const nameIdentifierClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
const nameClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
const dateOfBirthClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth";
const emailClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
const userProfileImageClaimTypeKey = "profile-image";

//Values of ClaimTypes
const adminRoleClaimTypeValue = "Admin";

// Axios configuration
let axiosConfig = {
    headers: { Authorization: `Bearer ${sessionStorage.getItem("token")}` }
};

//Methods
function getDecodedToken() {
    const token = sessionStorage.getItem("token");
    if (token == null) {
        return "";
    }
    else {
        const decodedToken = jwt_decode(token);
        return decodedToken;
    }
}

function readUserEmailFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[emailClaimTypeKey];
}

function readUserIdFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameIdentifierClaimTypeKey];
}

function readUserBirthDayFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[dateOfBirthClaimTypeKey];
}

function readUserRoleFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[roleClaimTypeKey];
}

//function readUserProfilePictureFromToken() {
//    const decodedToken = getDecodedToken();
//    return decodedToken[userProfileImageClaimTypeKey];
//}

function hasUserAdminRole() {
    if (readUserRoleFromToken() === adminRoleClaimTypeValue) {
        return true;
    }
    else {
        return false;
    }
}