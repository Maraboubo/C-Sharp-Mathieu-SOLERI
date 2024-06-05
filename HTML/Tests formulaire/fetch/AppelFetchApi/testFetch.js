// JavaScript source code



const leBoutonGet = document.getElementById('boutonTestGet'); // S�lectionne le bouton dans le DOM
const leBoutonPost = document.getElementById('boutonTestPost'); // S�lectionne le bouton dans le DOM
const url = 'https://localhost:44372/api/utilisateur'; // URL de l'API

console.log("Le Js marche !!! ;-))")
console.log("Chargement en cours"); // Message initial de chargement

leBoutonGet.addEventListener('click', () => {// Ajoute un gestionnaire d'�v�nements de clic sur le bouton
    fetch(url) // Effectue une requ�te fetch � l'URL sp�cifi�e
        .then((resp) => {
            if (!resp.ok) { // V�rifie si la r�ponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de r�seau :' + resp.statusText); // Lance une erreur si la r�ponse n'est pas correcte
            }
            return resp.json(); // Transforme la r�ponse en JSON
        })
        .then(function (data) {
            let resultats = data; // Assigne les donn�es JSON � la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour it�rer sur chaque �l�ment du tableau
                console.log(resultat.id_Utilisateur + " " + resultat.uNom + " " + resultat.uPrenom); // Affiche les propri�t�s de chaque �l�ment
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un probl�me avec votre op�ration fetch :', error); // G�re les erreurs
        });
});


leBoutonPost.addEventListener('click', () => {

    var form = document.getElementById('monFormulaire'); // Transf�re les donn�es du formulaire dans la variable 'form'.

    var donneesFormulaire = new FormData(form); // R�cup�re les donn�es du formulaire

    // Convertit les donn�es en objet JSON
    var utilisateur = {};
    donneesFormulaire.forEach((value, key) => {
        utilisateur[key] = value;
    });

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(utilisateur)
    })
        .then((resp) => {
            if (!resp.ok) {
                throw new Error('Erreur de r�seau :' + resp.statusText);
            }
            return resp.json();
        })
        .then(function (data) {
            console.log("Nouvel Utilisateur:", data);
        })
        .catch(function (error) {
            console.error('Il y a eu un probl�me avec votre op�ration fetch :', error);
        });

    //const utilisateur = {
    //    id_vCode: 0, // Changez ce champ selon vos besoins qui pourrait venir d'un input de formulaire
    //    uNom: "unNouveauSoleri", // Changez ce champ selon vos besoins qui pourrait venir d'un input de formulaire
    //    uPrenom: "unNouveauMathieu",
    //    email: "uneAdresseAupif@unHebergeur.com",
    //    uIdentifiant: "unNouvelIdentifiant",
    //    uMotDePasse: "estCeQueMonPostMarche",
    //    adresse1: "uneNouvelleAdresse"
    //};

    //fetch(url, {
    //    method: 'POST',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    body: JSON.stringify(utilisateur)
    //})
    //    .then((resp) => {
    //        if (!resp.ok) {
    //            throw new Error('Erreur de r�seau :' + resp.statusText);
    //        }
    //        return resp.json();
    //    })
    //    .then(function (data) {
    //        console.log("Nouvel Utilisateur:", data);
    //    })
    //    .catch(function (error) {
    //        console.error('Il y a eu un probl�me avec votre op�ration fetch :', error);
    //    });
});