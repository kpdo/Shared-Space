var firebaseConfig = {
    apiKey: "AIzaSyA9pwZGRrZjyqqWnjwr3bLiBBGpTTjrVBw",
    authDomain: "sharedspace-1570120703736.firebaseapp.com",
    databaseURL: "https://sharedspace-1570120703736.firebaseio.com",
    projectId: "sharedspace-1570120703736",
    storageBucket: "sharedspace-1570120703736.appspot.com",
    messagingSenderId: "575332437632",
    appId: "1:575332437632:web:bdaecfeec4398d13f52065"
  };
  // Initialize Firebase
  firebase.initializeApp(firebaseConfig);

    // Get a reference to the storage service, which is used to create references in your storage bucket
    var storage = firebase.storage();


function uploadToFirebase() {
  var ref = storage.ref();
  var file = document.getElementById("file-upload").files[0];
  var fileName = file.name;
  var storageRef = firebase.storage().ref(fileName);

  var uploadTask = storageRef.put(file);

  uploadTask.on('state_changed', function(snapshot){
  // Observe state change events such as progress, pause, and resume
  // Get task progress, including the number of bytes uploaded and the total number of bytes to be uploaded
  var progress = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
  console.log('Upload is ' + progress + '% done');
  switch (snapshot.state) {
    case firebase.storage.TaskState.PAUSED: // or 'paused'
      console.log('Upload is paused');
      break;
    case firebase.storage.TaskState.RUNNING: // or 'running'
      console.log('Upload is running');
      break;
  }
}, function(error) {
  // Handle unsuccessful uploads
}, function() {
  // Handle successful uploads on complete
  // For instance, get the download URL: https://firebasestorage.googleapis.com/...
  uploadTask.snapshot.ref.getDownloadURL().then(function(downloadURL) {
    console.log('File available at', downloadURL);
    unityInstance.SendMessage('ModelManager', 'UploadModel', downloadURL);
  });
});
}
