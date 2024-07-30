--Test pour la modification de la fonctionnalité d'inscription au sein de l'Api afin qu'elle retourne un utilisateur.

INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)
VALUES (1, 2, 'LoginFinal', 'MotdePasseUltime', 'bla', 'bla', 'Jacques', 'Frere', '06.32.35.36.95', 'frereJacques@mail.com')
GO
SELECT * FROM INTERLOCUTEUR
WHERE mdpInter = 'MotdePasseUltime' AND mailInter = 'frereJacques@mail.com'
GO


--	Test en vue de l'amélioration de la fonctionnalité de connexion. Afin de renvoyer toutes les informations concernant l'interlocuteur.

SELECT id_Inter, prenomInter, nomInter, telInter, INTERLOCUTEUR.id_titre, INTERLOCUTEUR.id_agence, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR
INNER JOIN AGENCE
ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
INNER JOIN TITRE
ON INTERLOCUTEUR.id_titre = TITRE.id_titre
WHERE mailInter = 's.durand@agencenord.com' AND mdpInter = 'password123'


--	Test en vue de l'amélioration de la fonctionnalité de d'inscription. Afin de renvoyer toutes les informations concernant l'interlocuteur.

INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)
VALUES (1, 2, 'blabla', 'unModDePasse123', 'k', 'k', 'Michel', 'Michel', '06.32.24.58.56', 'sardou@michel.com')

SELECT id_Inter, prenomInter, nomInter, telInter, INTERLOCUTEUR.id_titre, INTERLOCUTEUR.id_agence, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR
INNER JOIN AGENCE ON INTERLOCUTEUR.id_agence = AGENCE.id_agence
INNER JOIN TITRE ON INTERLOCUTEUR.id_titre = TITRE.id_titre
WHERE mdpInter = 'unModDePasse123' AND mailInter = 'sardou@michel.com'

--	Test en vue de l'amélioration de la fonctionnalité de d'ajout de client.
--	détermination des attributs à retourner à la partie 'front' afin de créer un constructeur dans l'api.

INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
VALUES (1, 1, 3, 'Deloin', 'Alain', 'qsd654aze987', '04.32.56.98.65', 'a.deloin@hotmail.com', '26', 1985-10-15, 'rue', 'de', 'la', null, null);
SELECT * FROM CLIENTS
INNER JOIN VILLES
ON CLIENTS.id_ville = VILLES.id_ville
INNER JOIN PAYS
ON VILLES.countryCode = PAYS.countryCode
INNER JOIN SEXE
ON CLIENTS.id_sexe = SEXE.id_sexe
INNER JOIN SECURITE_SOCIALE
ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu
WHERE numIdCli = '5'


INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
VALUES (1, 7, 3, 'Deloin', 'Alain', 'azertyuiop', '04.32.56.98.65', 'a.deloin@hotmail.com', '26', '1985-10-15', 'rue', 'de', 'la', null, null);
SELECT numIdCli, nomCli, prenomCli, nomSexe, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, postalCode, placeName, countryName, numCompteCli, numSecuCli, nomRegimeSecu FROM CLIENTS
INNER JOIN VILLES
ON CLIENTS.id_ville = VILLES.id_ville
INNER JOIN PAYS
ON VILLES.countryCode = PAYS.countryCode
INNER JOIN SEXE
ON CLIENTS.id_sexe = SEXE.id_sexe
INNER JOIN SECURITE_SOCIALE
ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu
WHERE numIdCli = 'azertyuiop'

--renvoi des des contrats de l'utilisateur connecté
SELECT id_Contr, nomCli, prenomCli, typContr, dateContr, fichierContr  FROM CONTRAT
INNER JOIN CLIENTS
ON CLIENTS.id_Cli = CONTRAT.id_Cli
INNER JOIN TYPE_CONTRAT
ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr
WHERE id_inter = 1009 and fichierContr is not null;