// JavaScript source code


/*
initiatisation des variables avec les id des éléments HTML.
*/
var bouttonStart = document.getElementById("boutonStart");
var bouttonPause = document.getElementById("boutonPause");
var bouttonStop = document.getElementById("boutonStop");
var reprendre = "Reprendre";
var pause = "Pause";
var chronometre = document.getElementById("timer");


var tpsEcoule = 0;

(function ()
{
    bouttonPause.paramTps = tpsEcoule;//ajouts des parametres "paramTps"
    bouttonStart.paramTps = tpsEcoule;//sur les boutons start et pause
    console.log("La fonction auto marche !!!");
    bouttonStart.addEventListener("click", startChrono, false);
}());

/*
Mise en place des évenements sur les boutons pause (lancement de la fonction pauseChrono())et stop (lancement de la fonction stopChrono())
*/
bouttonPause.addEventListener("click", pauseChrono);
bouttonStop.addEventListener("click", stopChrono);

function startChrono()
{
    chronometre.style.color = "black"; //ici on modifie la couleur d'un élément
    bouttonPause.innerHTML = pause; //ici on modifie l'affichage dans les balises d'un élément
    bouttonStart.style.color = "grey";
    bouttonPause.style.color = "black";
    bouttonStop.style.color = "black";
    /*
    RemoveEventListener retire l'évenement préalablement établi.
    */
    bouttonStart.removeEventListener("click", startChrono, false);
    bouttonPause.removeEventListener("click", startChrono, false);
    bouttonPause.addEventListener("click", pauseChrono, false);
    bouttonStop.addEventListener("click", stopChrono, false);
    
    var startTime = new Date();

    //bouttonStart.style.visibility = "hidden";
    bouttonPause.style.visibility = "visible";
    bouttonStop.style.visibility = "visible";

    //Cette fonction setInterval() sert a faire un décompte.
    decompte = setInterval(function () {

        var seconds = Math.round(
            (new Date().getTime() - startTime.getTime()) / 1000 + bouttonPause.paramTps);
        var hours = parseInt(seconds / 3600);
        seconds = seconds % 3600;

        var minutes = parseInt(seconds / 60);
        seconds = seconds % 60;

        chronometre.innerHTML = ajouteUnZero(hours)
            + ":" + ajouteUnZero(minutes)
            + ":" + ajouteUnZero(seconds);

        tpsEcoule += 1;
    }, 1000);
}
function ajouteUnZero(uniteDeTemps) {

    var valeurTemporele;

    if (uniteDeTemps < 10) {
        valeurTemporele = "0" + uniteDeTemps;
    }
    else {
        valeurTemporele = uniteDeTemps;
    }
    return valeurTemporele;
}
function pauseChrono()
{
    bouttonStart.style.color = "grey";
    bouttonStop.style.color = "black";
    bouttonPause.style.color = "black";

    chronometre.style.color = "green";//change la couleur du texte du chronometre
    bouttonPause.innerHTML = reprendre;

    clearInterval(decompte);//stoppe le "setInterval" dans la fonction "startChrono()"
    bouttonPause.removeEventListener("click", pauseChrono, false);//désactive l'evenement clic sur le bouton pause lançant la fonction "pauseChrono()"
    bouttonPause.paramTps = tpsEcoule;
    bouttonPause.addEventListener("click", startChrono, false);//active l'evenement clic sur le bouton pause lançant la fonction "startChrono()"
}
function stopChrono()
{
    chronometre.style.color = "red";
    bouttonStart.style.color = "black";
    bouttonPause.style.color = "grey";
    bouttonStop.style.color = "grey";

    bouttonStart.style.visibility = "visible";
    //bouttonPause.style.visibility = "hidden";
    //bouttonStop.style.visibility = "hidden";

    clearInterval(decompte);
    bouttonPause.removeEventListener("click", pauseChrono, false);
    bouttonStop.removeEventListener("click", stopChrono, false);
    bouttonStart.addEventListener("click", startChrono, false);
    tpsEcoule = 0;
    bouttonPause.paramTps=0;
    chronometre.innerHTML = "00:00:00";
}
    