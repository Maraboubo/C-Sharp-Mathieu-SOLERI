// JavaScript source code

const leBoutonGetPays = document.getElementById('boutonGetPays'); // Sélectionne le bouton dans le DOM
const leBoutonGetVilles = document.getElementById('boutonGetVilles');

/*const leBoutonPost = document.getElementById('boutonTestPost'); // Sélectionne le bouton dans le DOM*/
// URL de l'API
const france = 'FR';
const urlPays = 'http://api.geonames.org/countryInfoJSON?username=VOTRE_NOM_UTILISATEUR';
const urlVilles = 'http://api.geonames.org/searchJSON?country=FR&featureClass=P&maxRows=1000&username=VOTRE_NOM_UTILISATEUR';

console.log("Le Js marche !!! ;-))")
console.log("Chargement en cours"); // Message initial de chargement

fetch(urlVilles)
    .then(r => r.json())
    .then(data => console.log(data))

// Fonction pour remplir la liste déroulante des pays
async function populateCountryDropdown() {
    try {
        const response = await fetch(urlPays);
        const countries = await response.json();
        const pays = countries.geonames;

        const countryDropdown = document.getElementById('country');

        pays.forEach(country => {
            const option = document.createElement('option');
            option.value = country.countryCode; // Utilisez le code du pays comme valeur
            option.text = country.countryName; // Utilisez le nom du pays comme texte
            countryDropdown.appendChild(option);
        });
        // Ajouter un gestionnaire d'événements pour détecter le changement de sélection
        countryDropdown.addEventListener('change', async () => {
            const selectedCountry = countryDropdown.value;
            if (selectedCountry) {
                await populateCityDropdown(selectedCountry);
            } else {
                clearCityDropdown();
            }
        });
    } catch (error) {
        console.error('Erreur lors du chargement des pays:', error);
    }
}

// Fonction pour remplir la liste déroulante des villes
async function populateCityDropdown(countryCode) {
    try {
        const response = await fetch('http://api.geonames.org/searchJSON?country='+countryCode+'&featureClass=P&maxRows=1000&username=VOTRE_NOM_UTILISATEUR');
        const cities = await response.json();
        const villes = cities.geonames;

        const cityDropdown = document.getElementById('city');
        cityDropdown.innerHTML = ''; // Vider la liste des villes précédentes
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.text = 'Selectionnez une ville';
        cityDropdown.appendChild(defaultOption);

        villes.forEach(city => {
            const option = document.createElement('option');
            option.value = city.countryId; // Utilisez le nom de la ville comme valeur
            option.text = city.name; // Utilisez le nom de la ville comme texte
            cityDropdown.appendChild(option);
        });
    } catch (error) {
        console.error('Erreur lors du chargement des villes:', error);
    }
}

// Fonction pour vider la liste déroulante des villes
function clearCityDropdown() {
    const cityDropdown = document.getElementById('city');
    cityDropdown.innerHTML = ''; // Vider la liste des villes
    const defaultOption = document.createElement('option');
    defaultOption.value = '';
    defaultOption.text = 'Sélectionnez une ville';
    cityDropdown.appendChild(defaultOption);
}


// Appeler la fonction pour remplir la liste déroulante au chargement de la page
document.addEventListener('DOMContentLoaded', populateCountryDropdown);

leBoutonGetPays.addEventListener('click', () => {// Ajoute un gestionnaire d'événements de clic sur le bouton
    fetch(urlPays) // Effectue une requête fetch à l'URL spécifiée
        .then((resp) => {
            if (!resp.ok) { // Vérifie si la réponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de réseau :' + resp.statusText); // Lance une erreur si la réponse n'est pas correcte
            }
            return resp.json(); // Transforme la réponse en JSON
        })
        .then(function (data) {
            let resultats = data.geonames; // Assigne les données JSON à la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour itérer sur chaque élément du tableau
                console.log(resultat.countryName+ " " + resultat.countryCode); // Affiche les propriétés de chaque élément
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un problème avec votre opération fetch :', error); // Gère les erreurs
        });
});

leBoutonGetVilles.addEventListener('click', () => {// Ajoute un gestionnaire d'événements de clic sur le bouton
    fetch(urlVilles) // Effectue une requête fetch à l'URL spécifiée
        .then((resp) => {
            if (!resp.ok) { // Vérifie si la réponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de réseau :' + resp.statusText); // Lance une erreur si la réponse n'est pas correcte
            }
            return resp.json(); // Transforme la réponse en JSON
        })
        .then(function (data) {
            let resultats = data.geonames; // Assigne les données JSON à la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour itérer sur chaque élément du tableau
                console.log(resultat.countryName + " " + resultat.countryCode); // Affiche les propriétés de chaque élément
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un problème avec votre opération fetch :', error); // Gère les erreurs
        });
});
