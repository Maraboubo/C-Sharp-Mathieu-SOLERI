// JavaScript source code



const leBoutonGet = document.getElementById('boutonTestGet'); // Sélectionne le bouton dans le DOM
const leBoutonPost = document.getElementById('boutonTestPost'); // Sélectionne le bouton dans le DOM
const url = 'https://localhost:44372/api/utilisateur'; // URL de l'API

console.log("Le Js marche !!! ;-))")
console.log("Chargement en cours"); // Message initial de chargement

leBoutonGet.addEventListener('click', () => {// Ajoute un gestionnaire d'événements de clic sur le bouton
    fetch(url) // Effectue une requête fetch à l'URL spécifiée
        .then((resp) => {
            if (!resp.ok) { // Vérifie si la réponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de réseau :' + resp.statusText); // Lance une erreur si la réponse n'est pas correcte
            }
            return resp.json(); // Transforme la réponse en JSON
        })
        .then(function (data) {
            let resultats = data; // Assigne les données JSON à la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour itérer sur chaque élément du tableau
                console.log(resultat.id_Utilisateur + " " + resultat.uNom + " " + resultat.uPrenom); // Affiche les propriétés de chaque élément
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un problème avec votre opération fetch :', error); // Gère les erreurs
        });
});


leBoutonPost.addEventListener('click', () => {

    var form = document.getElementById('monFormulaire'); // Transfère les données du formulaire dans la variable 'form'.

    var donneesFormulaire = new FormData(form); // Récupère les données du formulaire

    // Convertit les données en objet JSON
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
                throw new Error('Erreur de réseau :' + resp.statusText);
            }
            return resp.json();
        })
        .then(function (data) {
            console.log("Nouvel Utilisateur:", data);
        })
        .catch(function (error) {
            console.error('Il y a eu un problème avec votre opération fetch :', error);
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
    //            throw new Error('Erreur de réseau :' + resp.statusText);
    //        }
    //        return resp.json();
    //    })
    //    .then(function (data) {
    //        console.log("Nouvel Utilisateur:", data);
    //    })
    //    .catch(function (error) {
    //        console.error('Il y a eu un problème avec votre opération fetch :', error);
    //    });
});