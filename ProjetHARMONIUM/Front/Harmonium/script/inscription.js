// JavaScript source code


/*
Déclaration des variables.
*/

pageUn = document.getElementById("conteneurInscription1");
pageDeux = document.getElementById("conteneurInscription2");
pageTrois = document.getElementById("conteneurInscription3");
pageQuatre = document.getElementById("conteneurInscription4");
boutonPageUn = document.getElementById("boutonSuivantP1");
retourPageUn = document.getElementById("flecheRetour1");
boutonPageDeux = document.getElementById("boutonSuivantP2");
retourPageDeux = document.getElementById("flecheRetour2");
boutonPageTrois = document.getElementById("boutonSuivantP3");
retourPageTrois = document.getElementById("flecheRetour3");
//variables des champs de remplissage du formulaire
eMail = document.getElementById("champMail");
motDePasse = document.getElementById("champMotDePasse");
nom = document.getElementById("champNom");
prenom = document.getElementById("champPrenom");
adresse1 = document.getElementById("champAdresse1");
adresse2 = document.getElementById("champAdresse2");
codePostal = document.getElementById("champCodePostal");
ville = document.getElementById("champVille");



var regex = /^[A-Za-z0-9_.@]+$/;
//regexChiffres selectionne les nombres.
var regexChiffres = /\d/;
var regexLettres = /[a-zA-Z]/;


//Utiliser ce display pour l'affichage de base.
pageUn.style.display = "block";
pageDeux.style.display = "none";
pageTrois.style.display = "none";
pageQuatre.style.display = "none";


//boutonPageUn.addEventListener("click", affichagePageDeux);
boutonPageUn.addEventListener("click", checkEmail);
retourPageUn.addEventListener("click", affichagePageUn);
//boutonPageDeux.addEventListener("click", affichagePageTrois);
boutonPageDeux.addEventListener("click", checkMotDePasse);
retourPageDeux.addEventListener("click", affichagePageDeux);
//boutonPageTrois.addEventListener("click", affichagePageQuatre);
boutonPageTrois.addEventListener("click", checkFormulaire);
retourPageTrois.addEventListener("click", affichagePageTrois);


function affichagePageUn() {
    pageUn.style.display = "block";
    pageDeux.style.display = "none";
    pageTrois.style.display = "none";
    pageQuatre.style.display = "none";
}
function affichagePageDeux() {
    pageUn.style.display = "none";
    pageDeux.style.display = "block";
    pageTrois.style.display = "none";
    pageQuatre.style.display = "none";
}
function affichagePageTrois(){
    pageUn.style.display = "none";
    pageDeux.style.display = "none";
    pageTrois.style.display = "block";
    pageQuatre.style.display = "none";
}
function affichagePageQuatre() {
    pageUn.style.display = "none";
    pageDeux.style.display = "none";
    pageTrois.style.display = "none";
    pageQuatre.style.display = "block";
}
/*
Check du mot du champ mail.
*/
function checkEmail() {
    if ((eMail.value).length == 0) {
        alert("Le Champ de texte est vide");
    }
    //La m�thode includes() vérifie la présence des caractères mentionnés
    else if ((eMail.value).includes('@') == false || (eMail.value).includes('.') == false) {
        alert("L'adresse entree doit comprter un caractere '@' et au moins un point.");
    }
    //Les méthodes startsWith() et endsWith() vérifie la présence des caractères mentionnés en début et fin de ligne
    else if ((eMail.value).startsWith('@') == true || (eMail.value).startsWith('.') == true) {
        alert("Les caract�re '@' et 'point', ne doivent pas se trouver en d�but de l'adresse.");
    }
    else if ((eMail.value).endsWith('@') == true || (eMail.value).endsWith('.') == true) {
        alert("Les caract�re '@' et 'point', ne doivent pas se trouver en d�but de l'adresse.");
    }
    //La méthode indexOf() vérifie renvoie la position des caractères mentionnés
    else if ((eMail.value).indexOf('@') > (eMail.value).indexOf('.')) {
        alert("Le caractere 'point', doit se trouver apres le caractere '@'.");
    }
    //La méthode test() vérifie renvoie la présence des caractéres mentionnés dans la variable regex déclarée en début de script
    else if (regex.test(eMail.value) == false) {
        console.log(regex.test(eMail.value));
        alert("L'addresse ne doit comporter que des chiffres, des lettres, '@', '.', '_'.");
    }
    else {
        affichagePageDeux();
    }
}
/*
Check du mot de passe.
*/
function validateMdp(input) {
    if (input.value.length == 0) {
    input.setCustomValidity("Votre mot de passe doit comporter au moins 1 caractère");
    }
    else if (input.value.length < 10) {
        input.setCustomValidity("Votre mot de passe doit comporter au moins 10 caractères");
    }
    else if ((regexChiffres.test(input.value) == false) || (regexLettres.test(input.value) == false)) {
        input.setCustomValidity("Le Mot de passe doit comporter au moins un chiffre et une lettre.");
    }
    else {
        input.setCustomValidity("");
    }
    input.reportValidity();
}
function checkMotDePasse() {

    if ((motDePasse.value).length == 0) {
        alert("Le Champ de texte est vide");
    }
    else if ((motDePasse.value).length < 10) {
        alert("Le Mot de passe doit comporter au moins 10 caractères.");
    }
    //La méthode test() vérifie renvoie la présence des caractères mentionnés dans la variable regex déclarée en début de script
    else if (regexChiffres.test(motDePasse.value) == false) {
        alert("Le Mot de passe doit comporter au moins un chiffre.");
    }
    else {
        affichagePageTrois();
    }
}
/*
Check du formulaire page3.
*/
function checkFormulaire() {
    //check champ nom
    if ((nom.value).length == 0) {
        alert("Le Champ 'Nom' est vide");
    }
    //check champ prénom
    else if ((prenom.value).length == 0) {
        alert("Le Champ 'Prénom' est vide");
    }
    //check champ adresse ligne 1
    else if ((adresse1.value).length == 0) {
        alert("Le Champ 'Adresse1' est vide");
    }
    //check champ adresse ligne 2
    else if ((adresse2.value).length == 0) {
        alert("Le Champ 'Adresse2' est vide");
    }
    //check champ code postal
    else if ((codePostal.value).length == 0) {
        alert("Le Champ 'Code postal' est vide");
    }
    //check champ ville
    else if ((ville.value).length == 0) {
        alert("Le Champ 'Ville' est vide");
    }
    else {
        affichagePageQuatre();
    }

}