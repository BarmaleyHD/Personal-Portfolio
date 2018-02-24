function saveToFirebase(email) {
    var emailObject = {
        email: email
    };

    firebase.database().ref('subscription-entries').push().set(emailObject)
        .then(function(snapshot) {
            success(); // some success method
        }, function(error) {
            console.log('error' + error);
            error(); // some error method
        });
}

saveToFirebase(email);

 // Get a reference to the database service
 var database = firebase.database();
 function writeUserData(value) {
 firebase.database().ref().child('text').set(value);
 firebase.database().ref().child('text')
 }

 // Initialize Firebase
 var config = {
    apiKey: "AIzaSyBJyE4JEba1bg-8ByOJBApEiCqaxZ_UlM4",
    authDomain: "personal-website-7b97e.firebaseapp.com",
    databaseURL: "https://personal-website-7b97e.firebaseio.com",
    projectId: "personal-website-7b97e",
    storageBucket: "",
    messagingSenderId: "548781222115"
};
firebase.initializeApp(config);