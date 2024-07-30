console.log("it runs")
OngletConnexion = document.getElementById('texteOngletUtilConnect');
BoutonSeDeconnecter = document.getElementById('boutonDeconnexion');
DivUtilisateur = document.getElementById('boutonUtilConnect');
BoutonConnexion = document.getElementById('boutonConnexion');
BoutonInscription = document.getElementById('boutonInscription');
//Boutons en lien vers les interfaces.
BoutonAssurance = document.getElementById('interfaceUn');
BoutonSim = document.getElementById('interfaceDeux');
BoutonCarteBancaire = document.getElementById('interfaceTrois');
BoutonMutuelle = document.getElementById('interfaceQuatre');
//Page Interlocuteurs.
PageInterlocuteurs = document.getElementById('intercalaire');
CroixInterlocuteurs = document.getElementById('fermer-intercalaire');
IdentifiantsInterlocuteur = document.getElementById('interlocuteurEspace');
PageInfos = document.getElementById('pageInfoPerso');
PageContrats = document.getElementById('pageContrat');
PageStatistiques = document.getElementById('pageStatistiques');

DivUtilisateur.addEventListener('click', affichagePageInterlocuteur);
CroixInterlocuteurs.addEventListener('click', fermerPageInterlocuteur);

function affichagePageInterlocuteur() {
    const Interlocuteur = JSON.parse(localStorage.getItem('user'));
    PageInterlocuteurs.style.display = 'block';
    affichageContrats();
    IdentifiantsInterlocuteur.innerText = `${Interlocuteur.prenomInter} ${Interlocuteur.nomInter}`;
}
function affichageInfoPerso() {
    PageInfos.style.display = 'block';
    PageContrats.style.display = 'none';
    PageStatistiques.style.display = 'none';
}
function affichageContrats() {
    PageInfos.style.display = 'none';
    PageContrats.style.display = 'block';
    PageStatistiques.style.display = 'none';
}
function affichageStatistiques() {
    PageInfos.style.display = 'none';
    PageContrats.style.display = 'none';
    PageStatistiques.style.display = 'block';
}
function fermerPageInterlocuteur() {
    PageInterlocuteurs.style.display = 'none';
}

document.addEventListener('DOMContentLoaded', ChargementUtilisateur);
function ChargementUtilisateur()
{
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        OngletConnexion.innerText = `${user.prenomInter} \n ${user.nomInter}`;
        DivUtilisateur.style.display = 'block';
        BoutonSeDeconnecter.style.display = 'block';
        BoutonConnexion.style.display = 'none';
        BoutonInscription.style.display = 'none';

        BoutonAssurance.href = 'AssuranceCreadocs.html';
        BoutonSim.href = 'AssuranceCreadocs.html';
        BoutonCarteBancaire.href = 'AssuranceCreadocs.html';
        BoutonMutuelle.href = 'AssuranceCreadocs.html';
    }
    else
    {
        DivUtilisateur.style.display = 'none';
        BoutonSeDeconnecter.style.display = 'none';
        BoutonConnexion.style.display = 'block';
        BoutonInscription.style.display = 'block';

        BoutonAssurance.href = 'ConnexionCreadocs.html';
        BoutonSim.href = 'ConnexionCreadocs.html';
        BoutonCarteBancaire.href = 'ConnexionCreadocs.html';
        BoutonMutuelle.href = 'ConnexionCreadocs.html';
    }
}

BoutonSeDeconnecter.addEventListener('click', Deconnexion);
function Deconnexion()
{
    localStorage.removeItem('user'); // Effacer le stockage local
    window.location.reload(); // Recharger la page pour appliquer les modifications
}