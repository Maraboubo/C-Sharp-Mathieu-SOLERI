
/*
Déclaration des variables.
*/

//Eléments de la fonctionalité GéoNames
const urlPays = 'http://api.geonames.org/countryInfoJSON?username=mathieusoleri';
const urlSexe = 'https://localhost:44338/api/sexe'; // URL pour les sexes
const urlSecu = 'https://localhost:44338/api/secu'; // URL pour les Régimes de sécurité sociales
const username = 'mathieusoleri'; // Remplacer par le username de inteligent document system


//Eléments de la page
ongletUtilisateur = document.getElementById("utilisateur");
//Encapsultion de l'utilisateur dans une variable
const user = JSON.parse(localStorage.getItem('user'));

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
//Affichage du nom et prénom de l'utilisateur présent dans le 'Local storage'
ongletUtilisateur.innerText = `${user.prenomInter} \n ${user.nomInter}`;



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

/*
    Peuplement des choix déroulants grâce à l'Api GéoNames.
*/

// Fonction pour remplir la liste déroulante des pays
async function populateCountryDropdown() {
    try {
        const response = await fetch(urlPays);
        const countries = await response.json();
        const pays = countries.geonames;

        const countryDropdown = document.getElementById('countryName');

        pays.forEach(country => {
            const option = document.createElement('option');
            option.value = country.countryCode; // Utilisez le code du pays comme valeur
            option.text = country.countryName; // Utilisez le nom du pays comme texte
            countryDropdown.appendChild(option);
        });
    } catch (error) {
        console.error('Erreur lors du chargement des pays:', error);
    }
}

// Fonction pour remplir la liste déroulante des villes
async function populateCityDropdown(countryCode, postalCode) {
    try {
        const response = await fetch(`http://api.geonames.org/postalCodeSearchJSON?postalcode=${postalCode}&country=${countryCode}&maxRows=500&username=${username}`);
        const cities = await response.json();
        const villes = cities.postalCodes;

        const cityDropdown = document.getElementById('placeName');
        cityDropdown.innerHTML = ''; // Vider la liste des villes précédentes
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.text = 'Sélectionnez une ville';
        cityDropdown.appendChild(defaultOption);

        villes.forEach(city => {
            const option = document.createElement('option');
            option.value = city.placeName; // Utilisez le nom de la ville comme valeur
            option.text = city.placeName; // Utilisez le nom de la ville comme texte
            cityDropdown.appendChild(option);
        });
    } catch (error) {
        console.error('Erreur lors du chargement des villes:', error);
    }
}

// Fonction pour vider la liste déroulante des villes
function clearCityDropdown() {
    const cityDropdown = document.getElementById('placeName');
    cityDropdown.innerHTML = ''; // Vider la liste des villes
    const defaultOption = document.createElement('option');
    defaultOption.value = '';
    defaultOption.text = 'Sélectionnez une ville';
    cityDropdown.appendChild(defaultOption);
}

// Ajouter un gestionnaire d'événements pour détecter le changement de sélection du pays
document.getElementById('countryName').addEventListener('change', () => {
    const selectedCountry = document.getElementById('countryName').value;
    if (selectedCountry) {
        document.getElementById('postalCode').addEventListener('input', () => {
            const postalCode = document.getElementById('postalCode').value;
            if (postalCode) {
                populateCityDropdown(selectedCountry, postalCode);
            } else {
                clearCityDropdown();
            }
        });
    } else {
        clearCityDropdown();
    }
});

/*
     Peuplement du choix déroulant sexe.
*/

// Fonction pour remplir la liste déroulante des sexes
async function populateSexeDropdown() {
    try {
        const response = await fetch(urlSexe);
        const sexes = await response.json();

        const sexeDropdown = document.getElementById('sexeCli');

        sexes.forEach(sexe => {
            const option = document.createElement('option');
            option.value = sexe.id_sexe; // Utilisez l'id de l'agence comme valeur
            option.text = sexe.nomSexe; // Utilisez le nom de l'agence comme texte
            sexeDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des sexes:', error);
    }
}

// Fonction pour remplir la liste déroulante des régimes de sécurité sociale
async function populateSecuDropdown() {
    try {
        const response = await fetch(urlSecu);
        const secus = await response.json();

        const secuDropdown = document.getElementById('id_regimeSecu');

        secus.forEach(secu => {
            const option = document.createElement('option');
            option.value = secu.id_regimeSecu; // Utilisez l'id de l'agence comme valeur
            option.text = secu.nomRegimeSecu; // Utilisez le nom de l'agence comme texte
            secuDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des sexes:', error);
    }
}



// Appeler la fonction pour remplir la liste déroulante des pays au chargement de la page
document.addEventListener('DOMContentLoaded', populateCountryDropdown);
// Appeler la fonction pour remplir la liste déroulante des sexes au chargement de la page
document.addEventListener('DOMContentLoaded', populateSexeDropdown);
// Appeler la fonction pour remplir la liste déroulante des sexes au chargement de la page
document.addEventListener('DOMContentLoaded', populateSecuDropdown);