// JavaScript source code
console.log("le script marche");

pageUn = document.getElementById("conteneurInscription1");
pageDeux = document.getElementById("conteneurInscription2");
pageTrois = document.getElementById("conteneurInscription3");
pageQuatre = document.getElementById("conteneurInscription4");
boutonPageUn = document.getElementById("boutonSuivantP1");
retourPageUn = document.getElementById("flecheRetour1");
boutonPageDeux = document.getElementById("boutonSuivantP2");
retourPageDeux = document.getElementById("flecheRetour2");
boutonPageTrois = document.getElementById("boutonSuivantP3")


//Utiliser ce display pour l'affichage de base.
pageUn.style.display = "block";
pageDeux.style.display = "none";
pageTrois.style.display = "none";
pageQuatre.style.display = "none";

/*
//Supprimer le display suivant
pageUn.style.display = "none";
pageDeux.style.display = "none";
pageTrois.style.display = "none";
pageQuatre.style.display = "none";
*/

boutonPageUn.addEventListener("click", affichagePageDeux);
retourPageUn.addEventListener("click", affichagePageUn);
boutonPageDeux.addEventListener("click", affichagePageTrois);
retourPageDeux.addEventListener("click", affichagePageDeux);
boutonPageTrois.addEventListener("click", affichagePageQuatre);

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


