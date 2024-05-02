const cloudinary = require('cloudinary').v2;

cloudinary.config({
  cloud_name: 'dmqkekbgg',
  api_key: '929344438526811',
  api_secret: 'z-Nv4uyxNglmkUPdNLVKJ9SXXHI'
});

const images = [
  'C:/Users/Utilisateur/Desktop/caluireMobileApp/FrontEnd/src/asset/images/iphone14.png',
  'C:/Users/Utilisateur/Desktop/caluireMobileApp/FrontEnd/src/asset/images/samsung s22.png',
  'C:/Users/Utilisateur/Desktop/caluireMobileApp/FrontEnd/src/asset/images/google pixel7.png'
];

images.forEach(image => {
  cloudinary.uploader.upload(image, function(error, result) {
    console.log(result, error);
  });
});