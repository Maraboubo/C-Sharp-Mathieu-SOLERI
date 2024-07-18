CREATE DATABASE creaDocs
GO

USE creaDocs
GO

CREATE TABLE SEXE
(
id_sexe INT IDENTITY(1,1) NOT NULL,

abrSexe VARCHAR(5) NOT NULL,
nomSexe VARCHAR(25) NOT NULL,

CONSTRAINT PK_SEXE PRIMARY KEY (id_sexe)
)
GO

CREATE TABLE SECURITE_SOCIALE
(
id_regimeSecu INT IDENTITY(1,1) NOT NULL,

nomRegimeSecu VARCHAR(50) NOT NULL,

CONSTRAINT PK_SECURITE_SOCIAL PRIMARY KEY (id_regimeSecu),
)
GO
--PREMIERE VERSION DE LA TABLE PAYS
--CREATE TABLE PAYS
--(
--id_pays INT NOT NULL,
--nomPays VARCHAR(50) NOT NULL,

--CONSTRAINT PK_PAYS PRIMARY KEY (id_pays)
--)
--GO

CREATE TABLE PAYS
(
countryCode VARCHAR(10) NOT NULL,
countryName VARCHAR(50) NOT NULL,

CONSTRAINT PK_PAYS PRIMARY KEY (countryCode)
)
GO

--PREMIERE VERSION DE LA TABLE VILLES
--CREATE TABLE VILLES
--(
--id_ville INT NOT NULL,
--id_pays INT NOT NULL,

--codePostVille VARCHAR(10) NOT NULL,
--nomVille VARCHAR(50) NOT NULL,

--CONSTRAINT PK_VILLE PRIMARY KEY (id_ville),
--CONSTRAINT FK_VILLE FOREIGN KEY (id_pays) REFERENCES PAYS (id_pays)
--)
--GO

CREATE TABLE VILLES
(
id_ville INT IDENTITY(1,1) NOT NULL,
countryCode VARCHAR(10) NOT NULL,

postalCode VARCHAR(20) NOT NULL,
placeName VARCHAR(100) NOT NULL,

CONSTRAINT PK_VILLE PRIMARY KEY (id_ville),
CONSTRAINT FK_VILLE FOREIGN KEY (countryCode) REFERENCES PAYS (countryCode)
)
GO

CREATE TABLE CLIENTS
(
id_Cli INT IDENTITY(1,1) NOT NULL,
id_sexe INT NOT NULL,
id_ville INT NOT NULL,
id_regimeSecu INT NULL,

nomCli VARCHAR(25) NOT NULL,
prenomCli VARCHAR(25) NOT NULL,
numIdCli VARCHAR(50) NOT NULL,
telCli VARCHAR(25) NULL,
mailCli VARCHAR(50) NULL,
depNaIssCli INT NULL,
dateNaissCli DATE NULL,
add1Cli VARCHAR(25) NULL,
add2Cli VARCHAR(25) NULL,
add3Cli VARCHAR(25) NULL,
numCompteCli VARCHAR(50) NULL,
numSecuCli VARCHAR(15) NULL,

CONSTRAINT PK_CLIENTS PRIMARY KEY (id_Cli),
CONSTRAINT FK_CLIENTS_SEXE FOREIGN KEY (id_sexe) REFERENCES SEXE (id_sexe),
CONSTRAINT FK_CLIENTS_VILLE FOREIGN KEY (id_ville) REFERENCES VILLES (id_ville),
CONSTRAINT FK_CLIENTS_SECURITE_SOCIALE FOREIGN KEY (id_regimeSecu) REFERENCES SECURITE_SOCIALE (id_regimeSecu),
)
GO

CREATE TABLE TYPE_CONTRAT
(
id_typContr INT IDENTITY(1,1) NOT NULL,

typContr VARCHAR(25) NOT NULL,

CONSTRAINT PK_TYPE_CONTRAT PRIMARY KEY (id_typContr),
)
GO

CREATE TABLE TYPE_CARTE
(
id_type INT IDENTITY(1,1) NOT NULL,

nomType VARCHAR(25) NOT NULL,
retMaxSemKwFr INT NOT NULL,
retMaxSemAbFr INT NOT NULL,
retTotalSemFr INT NOT NULL,
retMaxSemAbEtr INT NOT NULL,
retTotalSemEtr INT NOT NULL,
retMaxAuto INT NOT NULL,
paiMaxSemFr INT NOT NULL,
paiMaxSemEtr INT NOT NULL,
paiMaxSemTotal INT NOT NULL,
paiMaxMoisFr INT NOT NULL,
paiMaxMoisEtr INT NOT NULL,
paiMaxMoisTotal INT NOT NULL,

CONSTRAINT PK_TYPE_CARTE PRIMARY KEY (id_type)
)
GO

CREATE TABLE CARTE_BANCAIRE
(
numCarte INT NOT NULL,
id_type INT NOT NULL,

dateDebutCarte DATE NOT NULL,
dateFinCarte DATE NOT NULL,

CONSTRAINT PK_CARTE_BANCAIRE PRIMARY KEY (numCarte),
CONSTRAINT FK_CARTE_BANCAIRE FOREIGN KEY (id_type) REFERENCES TYPE_CARTE (id_type),
)
GO

CREATE TABLE ASSURANCE
(
id_Assu INT IDENTITY(1,1) NOT NULL,

nomAssu VARCHAR(50) NOT NULL,
valeurAssu INT NOT NULL,

CONSTRAINT PK_ASSURANCE PRIMARY KEY (id_Assu),
)
GO

CREATE TABLE MUTUELLE
(
id_mutu INT IDENTITY(1,1) NOT NULL,

nomMutu VARCHAR(25) NOT NULL,
valeurMutu DECIMAL NOT NULL,

CONSTRAINT PK_MUTUELLE PRIMARY KEY (id_mutu),
)
GO

CREATE TABLE TITRE
(
id_titre INT IDENTITY(1,1) NOT NULL,

nomTitre VARCHAR(25) NOT NULL,

CONSTRAINT PK_TITRE PRIMARY KEY (id_titre),
)
GO

CREATE TABLE AGENCE
(
id_agence INT IDENTITY(1,1) NOT NULL,

nomAgence VARCHAR(25) NOT NULL,
nomDirAgence VARCHAR(25) NOT NULL,
prenomDirAgence VARCHAR(25) NOT NULL,

CONSTRAINT PK_AGENCE PRIMARY KEY (id_agence),
)
GO

CREATE TABLE INTERLOCUTEUR
(
id_inter INT IDENTITY(1,1) NOT NULL,
id_titre INT NULL,
id_agence INT NULL,

loginInter VARCHAR(25) NOT NULL,
mdpInter VARCHAR(25) NOT NULL,
loginKwInter VARCHAR(25) NULL,
mdpKwInter VARCHAR(25) NULL,
nomInter VARCHAR(25) NOT NULL,
prenomInter VARCHAR(25) NOT NULL,
telInter VARCHAR(25) NULL,
mailInter VARCHAR(50) NOT NULL,

CONSTRAINT PK_INTERLOCUTEUR PRIMARY KEY (id_inter),
CONSTRAINT FK_INTERLOCUTEUR_TITRE FOREIGN KEY (id_titre) REFERENCES TITRE (id_titre),
CONSTRAINT FK_INTERLOCUTEUR_AGENCE FOREIGN KEY (id_agence) REFERENCES AGENCE (id_agence),
)
GO

CREATE TABLE MODE_PAIEMENT
(
id_modePai INT IDENTITY(1,1) NOT NULL,

nomModePai VARCHAR(25) NOT NULL,

CONSTRAINT PK_MODE_PAIEMENT PRIMARY KEY (id_modePai),
)
GO

CREATE TABLE TYPE_SIM
(
id_typeSim INT IDENTITY(1,1) NOT NULL,

nomTypeSim VARCHAR(25) NOT NULL,
valeurTypeSim INT NOT NULL,
nomRemiseTypeSim VARCHAR(12) NOT NULL,
valeurRemiseTypeSim DECIMAL NOT NULL,

CONSTRAINT PK_TYPE_SIM PRIMARY KEY (id_typeSim),
)
GO

CREATE TABLE CARTE_SIM
(
numSim INT NOT NULL,
id_typeSim INT NOT NULL,
id_modePai INT NOT NULL,

numTelSim VARCHAR(25) NOT NULL,
numProvTelSim VARCHAR(25) NOT NULL,
numRioSim VARCHAR(12) NOT NULL,
paiementSim DECIMAL NOT NULL,

CONSTRAINT PK_CARTE_SIM PRIMARY KEY (numSim),
CONSTRAINT FK_CARTE_SIM_TYPE FOREIGN KEY (id_typeSim) REFERENCES TYPE_SIM (id_typeSim),
CONSTRAINT FK_CARTE_SIM_PAIEMENT FOREIGN KEY (id_modePai) REFERENCES MODE_PAIEMENT (id_modePai),
)
GO 

CREATE TABLE CONTRAT
(
id_Contr INT IDENTITY(1,1) NOT NULL,
id_typContr INT NOT NULL,
numCarte INT NULL,
id_inter INT NULL,
id_Cli INT NOT NULL,
id_Assu INT NULL,
id_Mutu INT NULL,
numSim INT NULL,

dateContr DATE NOT NULL,
dateDebutContr DATE NULL,
dateFinContr DATE NULL,
fichierContr VARBINARY(MAX) NULL,

CONSTRAINT PK_CONTRAT PRIMARY KEY (id_Contr),
CONSTRAINT FK_CONTRAT_TYPE_CONTRAT FOREIGN KEY (id_typContr) REFERENCES TYPE_CONTRAT (id_typContr),
CONSTRAINT FK_CONTRAT_CARTE_BANCAIRE FOREIGN KEY (numCarte) REFERENCES CARTE_BANCAIRE (numCarte),
CONSTRAINT FK_CONTRAT_INTERLOCUTEUR FOREIGN KEY (id_inter) REFERENCES INTERLOCUTEUR (id_inter),
CONSTRAINT FK_CONTRAT_CLIENTS FOREIGN KEY (id_Cli) REFERENCES CLIENTS (id_Cli),
CONSTRAINT FK_CONTRAT_ASSURANCE FOREIGN KEY (id_Assu) REFERENCES ASSURANCE (id_Assu),
CONSTRAINT FK_CONTRAT_MUTUELLE FOREIGN KEY (id_Mutu) REFERENCES MUTUELLE (id_Mutu),
CONSTRAINT FK_CONTRAT_CARTE_SIM FOREIGN KEY (numSim) REFERENCES CARTE_SIM (numSim),
)
GO