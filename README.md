# Exercice : trouver les paragraphes

Demander l'accès au ["miro" de l'exercice **Trouver les paragraphes**](https://miro.com/welcomeonboard/N04vN1V6TkNmaWRwM29IVmxxVldYNTNVY0VQUGtuczZFVlBpaDgrMjAxQUk1VGpmYkNxYTdHQ0dtKzZIeXJGdVRYdlV5dlVnQTBwQzVaRUpVUHArQzdkb0thS1B6bklkaCtGM21rRkNsVTdpWUlnSWtBbTdEMWI0SEk1Ykt5RVBNakdSWkpBejJWRjJhRnhhb1UwcS9BPT0hdjE=?share_link_id=371415599064)

# Theatrical Players Refactoring Kata
## Français
_Soutenez ceci et tous les Kata d'Emily's katas via [Patreon](https://www.patreon.com/EmilyBache)_

### Origine
Le premier chapitre de ['Refactoring' by Martin Fowler, 2nd Edition](https://www.thoughtworks.com/books/refactoring2) contient un exemple travaillé de cet exercice, en javascript. Ce chapitre est disponible en téléchargement gratuit. Ce repo contient le point de départ de cet exercice dans plusieurs langues, avec des tests, afin que vous puissiez l'essayer par vous-même.

### Descriptif du Kata

“Imaginez une compagnie d'acteurs de théâtre qui se rend à divers événements pour y jouer des pièces. 
En général, un client demande quelques pièces de théâtre et la compagnie le facture en fonction de la taille du public et du type de pièce qu'elle joue.
Actuellement, la compagnie joue deux types de pièces : les tragédies et les comédies. 
En plus de fournir une facture pour la représentation, la société donne à ses clients des « crédits de volume » qu'ils peuvent utiliser pour obtenir des réductions sur les représentations futures - il s'agit d'un mécanisme de fidélisation de la clientèle.”

### Travail d'Emily
Emily a réalisé une vidéo ["Refactoring with Martin Fowler | Theatrical Players Code Kata"](https://youtu.be/TjIrKEaOiVw) qui explique un peu l'exercice et pourquoi vous devriez l'essayer.

Elle a également réalisée une [démo en Javascript](https://youtu.be/cZJ36B3iXok) avec l'éditeur Webstorm (Jetbrain).

### Ce qu'il faut changer
Le refactoring est généralement motivé par la nécessité d'apporter des changements. Dans le livre : 
* Fowler veux ajouter du code pour imprimer la déclaration en HTML en plus de la version en texte brut existante.
* Il mentionne également que les acteurs de théâtre veulent ajouter de nouveaux types de pièces à leur répertoire, par exemple des pièces historiques et pastorales.

### Tests automatisés
Dans son livre, Fowler mentionne que la première étape du remaniement est toujours la même : s'assurer que l'on dispose d'un ensemble solide de tests pour cette section du code. Cependant, Fowler n'a pas inclus le code de test pour cet exemple dans son livre. Emily a utilisé une approche [Approval testing](https://medium.com/97-things/approval-testing-33946cde4aa8) et ajouté quelques tests. Elle trouve que les tests d'approbation sont une technique puissante pour mettre rapidement le code existant sous test et pour soutenir le remaniement. Vous devriez examiner ces tests et vous assurer que vous comprenez ce qu'ils couvrent et quels types d'erreurs de remaniement ils s'attendent à trouver.

## English (original from Emily)
_Support this and all Emily's katas via [Patreon](https://www.patreon.com/EmilyBache)_

The first chapter of ['Refactoring' by Martin Fowler, 2nd Edition](https://www.thoughtworks.com/books/refactoring2) contains a worked example of this exercise, in javascript. That chapter is available to download for free. This repo contains the starting point for this exercise in several languages, with tests, so you can try it out for yourself.

Emily made a video ["Refactoring with Martin Fowler | Theatrical Players Code Kata"](https://youtu.be/TjIrKEaOiVw) that explains a little bit about the exercise and why you should give it a try.

### What you need to change
Refactoring is usually driven by a need to make changes. In the book, Fowler adds code to print the statement as HTML in addition to the existing plain text version. He also mentions that the theatrical players want to add new kinds of plays to their repertoire, for example history and pastoral.

### Automated tests
In his book Fowler mentions that the first step in refactoring is always the same - to ensure you have a solid set of tests for that section of code. However, Fowler did not include the test code for this example in his book. I have used an [Approval testing](https://medium.com/97-things/approval-testing-33946cde4aa8) approach and added some tests. I find Approval testing to be a powerful technique for rapidly getting existing code under test and to support refactoring. You should review these tests and make sure you understand what they cover and what kinds of refactoring mistakes they would expect to find.

Acknowledgements
Thankyou to Martin Fowler for kindly giving permission to use his code.

## Liens
* https://youtu.be/TjIrKEaOiVw Introducing the kata
* https://youtu.be/cZJ36B3iXok Javascript Demo 
