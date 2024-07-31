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

/*
    Intégration de la fonction de chargement des contrats:
*/

function PeuplementContrats()
{
    const contenu = document.getElementById('contenu');
    const interlocuteur = JSON.parse(localStorage.getItem('user')); // Adjust the key name if different
    const identifiantUtilisateur = interlocuteur.id_inter;

    if (interlocuteur)
    {
        fetchContracts(identifiantUtilisateur); // Assuming `id` is a property of `Interlocuteur`
    }
    else
    {
        alert('No user logged in');
    }

    function fetchContracts(interlocuteurId)
    {
        fetch(`https://localhost:44338/api/contrat/${interlocuteurId}`) // Adjust the endpoint URL
            .then(response => response.json())
            .then(contracts => {
                displayContracts(contracts);
            })
            .catch(error => {
                console.error('Error fetching contracts:', error);
            });
    }

    function displayContracts(contracts)
    {
        contracts.forEach(contract => {
            const contractRow = document.createElement('div');
            contractRow.classList.add('contract-row');
            const pdfBlob = base64ToBlob(contract.fichierContr, 'application/pdf');
            const pdfUrl = URL.createObjectURL(pdfBlob);

            contractRow.innerHTML = `
                <div class="ligneInfoDocument">Numero de contrat : ${contract.id_Contr}</div>
                <div class="ligneInfoDocument">Nom du client : ${contract.nomCli}</div>
                <div class="ligneInfoDocument">prenom du client : ${contract.prenomCli}</div>
                <div class="ligneInfoDocument">Type de contrat : ${contract.typContr}</div>
                <div class="ligneInfoDocument">Date du contrat : ${contract.dateContr}</div>
                <div class="document-preview-container">
                   <iframe src="${pdfUrl}" title="Document Preview"></iframe>
                </div>
            `;

            // Créez le bouton pour ouvrir le PDF dans une nouvelle fenêtre
            const openButton = document.createElement('button');
            openButton.classList.add('boutonDocument');
            openButton.textContent = 'Ouvrir le document';
            openButton.addEventListener('click', (event) => {
                event.preventDefault();
                window.open(pdfUrl, '_blank');
            });

            // Ajoutez le bouton après l'iframe
            /*contractRow.querySelector('div').appendChild(openButton);*/
            const previewContainer = contractRow.querySelector('.document-preview-container');
            previewContainer.appendChild(openButton);

            // Ajoutez la ligne de contrat à la div 'contenu'
            contenu.appendChild(contractRow);
        });
    }
    function base64ToBlob(base64, mime) {
        const byteCharacters = atob(base64);
        const byteNumbers = new Array(byteCharacters.length);

        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        return new Blob([byteArray], { type: mime });
    }
};

document.addEventListener('DOMContentLoaded', PeuplementContrats);
