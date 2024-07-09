
// URL de l'API
const urltitre = 'https://localhost:44338/api/titre';

// Fonction pour remplir la liste déroulante des fonctions des employés
async function populateTitreDropdown() {
    try {
        const response = await fetch(urltitre);
        const titres = await response.json();

        const titreDropdown = document.getElementById('id_titre');

        titres.forEach(titre => {
            const option = document.createElement('option');
            option.value = titre.id_titre; // Utilisez l'id de la fonction des employés comme valeur
            option.text = titre.nomTitre; // Utilisez le nom de la fonction des employés comme texte
            titreDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des titres:', error);
    }
}

// Appeler la fonction pour remplir la liste déroulante au chargement de la page
document.addEventListener('DOMContentLoaded', populateTitreDropdown);
