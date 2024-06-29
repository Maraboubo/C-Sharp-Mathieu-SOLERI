// JavaScript source code

const leBoutonGetPays = document.getElementById('boutonGetPays'); // S�lectionne le bouton dans le DOM
const leBoutonGetVilles = document.getElementById('boutonGetVilles');

/*const leBoutonPost = document.getElementById('boutonTestPost'); // S�lectionne le bouton dans le DOM*/
// URL de l'API
const france = 'FR';
const urlPays = 'http://api.geonames.org/countryInfoJSON?username=VOTRE_NOM_UTILISATEUR';
const urlVilles = 'http://api.geonames.org/searchJSON?country=FR&featureClass=P&maxRows=1000&username=VOTRE_NOM_UTILISATEUR';

console.log("Le Js marche !!! ;-))")
console.log("Chargement en cours"); // Message initial de chargement

fetch(urlVilles)
    .then(r => r.json())
    .then(data => console.log(data))

// Fonction pour remplir la liste d�roulante des pays
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
        // Ajouter un gestionnaire d'�v�nements pour d�tecter le changement de s�lection
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

// Fonction pour remplir la liste d�roulante des villes
async function populateCityDropdown(countryCode) {
    try {
        const response = await fetch('http://api.geonames.org/searchJSON?country='+countryCode+'&featureClass=P&maxRows=1000&username=VOTRE_NOM_UTILISATEUR');
        const cities = await response.json();
        const villes = cities.geonames;

        const cityDropdown = document.getElementById('city');
        cityDropdown.innerHTML = ''; // Vider la liste des villes pr�c�dentes
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

// Fonction pour vider la liste d�roulante des villes
function clearCityDropdown() {
    const cityDropdown = document.getElementById('city');
    cityDropdown.innerHTML = ''; // Vider la liste des villes
    const defaultOption = document.createElement('option');
    defaultOption.value = '';
    defaultOption.text = 'S�lectionnez une ville';
    cityDropdown.appendChild(defaultOption);
}


// Appeler la fonction pour remplir la liste d�roulante au chargement de la page
document.addEventListener('DOMContentLoaded', populateCountryDropdown);

leBoutonGetPays.addEventListener('click', () => {// Ajoute un gestionnaire d'�v�nements de clic sur le bouton
    fetch(urlPays) // Effectue une requ�te fetch � l'URL sp�cifi�e
        .then((resp) => {
            if (!resp.ok) { // V�rifie si la r�ponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de r�seau :' + resp.statusText); // Lance une erreur si la r�ponse n'est pas correcte
            }
            return resp.json(); // Transforme la r�ponse en JSON
        })
        .then(function (data) {
            let resultats = data.geonames; // Assigne les donn�es JSON � la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour it�rer sur chaque �l�ment du tableau
                console.log(resultat.countryName+ " " + resultat.countryCode); // Affiche les propri�t�s de chaque �l�ment
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un probl�me avec votre op�ration fetch :', error); // G�re les erreurs
        });
});

leBoutonGetVilles.addEventListener('click', () => {// Ajoute un gestionnaire d'�v�nements de clic sur le bouton
    fetch(urlVilles) // Effectue une requ�te fetch � l'URL sp�cifi�e
        .then((resp) => {
            if (!resp.ok) { // V�rifie si la r�ponse n'est pas correcte (statut HTTP autre que 200)
                throw new Error('Erreur de r�seau :' + resp.statusText); // Lance une erreur si la r�ponse n'est pas correcte
            }
            return resp.json(); // Transforme la r�ponse en JSON
        })
        .then(function (data) {
            let resultats = data.geonames; // Assigne les donn�es JSON � la variable 'resultats'
            resultats.forEach(function (resultat) { // Utilise forEach pour it�rer sur chaque �l�ment du tableau
                console.log(resultat.countryName + " " + resultat.countryCode); // Affiche les propri�t�s de chaque �l�ment
            });
        })
        .catch(function (error) {
            console.error('Il y a eu un probl�me avec votre op�ration fetch :', error); // G�re les erreurs
        });
});
