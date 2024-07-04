
/*
Déclaration des variables.
*/

pageUn = document.getElementById("conteneurAssurance1");
pageDeux = document.getElementById("conteneurAssurance2");
pageTrois = document.getElementById("conteneurAssurance3");

boutonPageUn = document.getElementById("boutonSuivantAssur1");
retourPageUn = document.getElementById("flecheRetour1");
boutonPageDeux = document.getElementById("boutonSuivantAssur2");
retourPageDeux = document.getElementById("flecheRetour2");



//Utiliser ce display pour l'affichage de base.
pageUn.style.display = "block";
pageDeux.style.display = "none";
pageTrois.style.display = "none";



//GESTION DE L'AFFICHAGE DES DIFFERENTES PAGES
boutonPageUn.addEventListener("click", affichagePageDeux);
retourPageUn.addEventListener("click", affichagePageUn);
boutonPageDeux.addEventListener("click", affichagePageTrois);
retourPageDeux.addEventListener("click", affichagePageDeux);


function affichagePageUn() {
    pageUn.style.display = "block";
    pageDeux.style.display = "none";
    pageTrois.style.display = "none";
    /*pageQuatre.style.display = "none";*/
}
function affichagePageDeux() {
    pageUn.style.display = "none";
    pageDeux.style.display = "block";
    pageTrois.style.display = "none";
    /*pageQuatre.style.display = "none";*/
}
function affichagePageTrois() {
    pageUn.style.display = "none";
    pageDeux.style.display = "none";
    pageTrois.style.display = "block";
    /*pageQuatre.style.display = "none";*/
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
    //else {
    //    affichagePageQuatre();
    //}
}
