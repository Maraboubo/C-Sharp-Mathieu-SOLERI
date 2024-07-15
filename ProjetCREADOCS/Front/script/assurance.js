
/*
Déclaration des variables.
*/

//Eléments de la fonctionalité GéoNames
const urlPays = 'http://api.geonames.org/countryInfoJSON?username=mathieusoleri';
const urlSexe = 'https://localhost:44338/api/sexe'; // URL pour les sexes
const urlSecu = 'https://localhost:44338/api/secu'; // URL pour les Régimes de sécurité sociales
const urlClient = 'https://localhost:44338/api/client'; // URL pour les Clients
const urlAssurance = 'https://localhost:44338/api/assurance'; // URL pour les Clients
const username = 'mathieusoleri'; // Remplacer par le username de inteligent document system


//Eléments de la page
ongletUtilisateur = document.getElementById("utilisateur");
champPays = document.getElementById("codePays");



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
pageUn.style.display = "none";
pageDeux.style.display = "block";
pageTrois.style.display = "none";
//Affichage du nom et prénom de l'utilisateur présent dans le 'Local storage'
ongletUtilisateur.innerText = `${user.prenomInter} \n ${user.nomInter}`;
//Dissimulation du champ de texte "Identifiant Pays"
champPays.style.display = "none";


//GESTION DE L'AFFICHAGE DES DIFFERENTES PAGES
/*boutonPageUn.addEventListener("click", envoiDataClient);*/
boutonPageUn.addEventListener("click", checkFormulaire);
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
Check du formulaire page1.
*/
function checkFormulaire() {
    //Elements de la page 'Client'
    const sexe = document.getElementById("id_sexe");
    const regSecu = document.getElementById("id_regimeSecu");
    const nom = document.getElementById("nomCli");
    const prenom = document.getElementById("prenomCli");
    const identite = document.getElementById("numIdCli");
    const naissance = document.getElementById("dateNaissCli");
    const adresse1 = document.getElementById("add1Cli");
    const adresse2 = document.getElementById("add2Cli");
    const adresse3 = document.getElementById("add3Cli");
    const codePostal = document.getElementById("postalCode");
    const ville = document.getElementById("placeName");
    const countryCode = document.getElementById("countryCode");
    const Pays = document.getElementById("countryName");

    //check champ numéro identité client 
    if ((identite.value).length == 0) {
        alert("Le Champ 'Nom' est vide");
    }
    //check champ nom
    else if ((nom.value).length == 0) {
        alert("Le Champ 'Nom' est vide");
    }
    //check champ prénom
    else if ((prenom.value).length == 0) {
        alert("Le Champ 'Prénom' est vide");
    }
    //check champ sexe
    else if ((sexe.value) < 1 || (sexe.value) > 3) {
        alert("Veuillez renseigner le champ 'Sexe' ");
    }
    //check champ date de naissance
    else if ((naissance.value).length == 0 ) {
        alert("Veuillez renseigner le champ 'Date de naissance' ");
    }
    //check champ sécurité sociale
    else if ((regSecu.value) < 1 || (regSecu.value) > 4) {
        alert("Veuillez renseigner le champ 'Régime de sécurité sociale' ");
    }
    //check champ adresse ligne 1
    else if ((adresse1.value).length == 0) {
        alert("Le Champ 'Adresse1' est vide");
    }
    //check champ Pays
    else if ((Pays.value).length == 0) {
        alert("Le Champ 'Pays' est vide");
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
        envoiDataClient();
        affichagePageDeux();
    }
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
    document.getElementById('countryCode').value = selectedCountry; // Mettre à jour le champ countryCode
    document.getElementById('countryCode').text = selectedCountry; // Mettre à jour le champ countryCode

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

//// Ajouter un gestionnaire d'événements pour détecter le changement de sélection du pays
//document.getElementById('countryName').addEventListener('change', () => {
//    const selectedCountry = document.getElementById('countryName').value;
//    if (selectedCountry) {
//        document.getElementById('postalCode').addEventListener('input', () => {
//            const postalCode = document.getElementById('postalCode').value;
//            if (postalCode) {
//                populateCityDropdown(selectedCountry, postalCode);
//            } else {
//                clearCityDropdown();
//            }
//        });
//    } else {
//        clearCityDropdown();
//    }
//});

/*
     Peuplement du choix déroulant sexe.
*/

// Fonction pour remplir la liste déroulante des sexes
async function populateSexeDropdown() {
    try {
        const response = await fetch(urlSexe);
        const sexes = await response.json();

        const sexeDropdown = document.getElementById('id_sexe');

        sexes.forEach(sexe => {
            const option = document.createElement('option');
            option.value = sexe.id_sexe; // On utilise l'id du sexe comme valeur
            option.text = sexe.nomSexe; // On Utilise nom du sexe comme texte
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
            option.value = secu.id_regimeSecu; // On utilise l'id de l'agence comme valeur
            option.text = secu.nomRegimeSecu; // On utilise le nom de l'agence comme texte
            secuDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des sexes:', error);
    }
}

async function envoiDataClient() {
    //Elements de la page 'Client'
    const sexe = document.getElementById("id_sexe").value;
    const regSecu = document.getElementById("id_regimeSecu").value;
    const nom = document.getElementById("nomCli").value;
    const prenom = document.getElementById("prenomCli").value;
    const identite = document.getElementById("numIdCli").value;
    const naissance = document.getElementById("dateNaissCli").value;
    const depardement = document.getElementById("depNaissCli").value;
    const adresse1 = document.getElementById("add1Cli").value;
    const adresse2 = document.getElementById("add2Cli").value;
    const adresse3 = document.getElementById("add3Cli").value;
    const postalCode = document.getElementById("postalCode").value;
    const placeName = document.getElementById("placeName").value;
    const countryCode = document.getElementById("countryCode").value;
    const countryDropdown = document.getElementById("countryName");
    const countryName = countryDropdown.options[countryDropdown.selectedIndex].text;

    const clientData = {
        id_sexe: sexe,
        id_ville: 0,
        id_regimeSecu: regSecu,
        nomCli: nom,
        prenomCli: prenom,
        numIdCli: identite,
        dateNaissCli: naissance,
        depNaissCli: depardement,
        add1Cli: adresse1,
        add2Cli: adresse2,
        add3Cli: adresse3,
    };

    const objetClient = JSON.stringify({ Client: clientData, postalCode, placeName, countryCode, countryName });

    const response = await fetch(urlClient, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: objetClient
    });
    console.log(objetClient);
    if (response.ok) {
        const client = await response.json();
        localStorage.setItem('client', JSON.stringify(client));
        // Passer à la prochaine partie du formulaire
        alert('Client enregistré avec succès');
    } else {
        console.error('Erreur lors de l\'enregistrement du client');
        alert('Erreur lors de l\'enregistrement du client');
    }
}

async function populateAssuranceDropdown() {
    try {
        const response = await fetch(urlAssurance);
        const assurances = await response.json();

        const assuranceDropdown = document.getElementById('id_assu');

        assurances.forEach(assurance => {
            const option = document.createElement('option');
            option.value = assurance.id_assurance; // On utilise l'id du sexe comme valeur
            option.text = assurance.nomAssu; // On Utilise nom du sexe comme texte
            assuranceDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des assurances:', error);
    }
}



// Appeler la fonction pour remplir la liste déroulante des pays au chargement de la page
document.addEventListener('DOMContentLoaded', populateCountryDropdown);
// Appeler la fonction pour remplir la liste déroulante des sexes au chargement de la page
document.addEventListener('DOMContentLoaded', populateSexeDropdown);
// Appeler la fonction pour remplir la liste déroulante des régimes de sécurité sociale au chargement de la page
document.addEventListener('DOMContentLoaded', populateSecuDropdown);
// Appeler la fonction pour remplir la liste déroulante des contrats d'assurance au chargement de la page
document.addEventListener('DOMContentLoaded', populateAssuranceDropdown);