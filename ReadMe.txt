Pour intégrer le travail des graphistes dans mon prototype, je vais poser des questions a un programmeur pour avoir des informations sur comment le moteur fonctionne. 

En effet, pour intégrer une animation, j'ai tout d'abord besoin d'un squelette sur lequel je vais la poser. Peut être qu'il se nomme "Avatar" comme dans unity. J'aimerai aussi savoir si le moteur va me bloquer si je pose une animation sur un squelette qui n'est pas le bon (unreal) ou si je vais pouvoir mettre mon animation sur n'importe quel squelette sans que cela marche au final car il n'y a pas de barrière (unity). Sur unity, il est en effet possible de d'avoir un avatar dans le character mais un autre avatar dans l'animator, sans que cela ne crée d'erreur, mais l'animation ne marchera pas. 

J'aimerai ensuite savoir comment je peux modifier le comportement de mon Character, ayant le squelette et les animations. Ai-je accès à ses modification directement à l'intérieur de mon character, ou dois-je créer un script en dehors et le lui lier? De plus, quel est le nom de la fonction me permettant de donner l'information à mon character de se déplacer? Où puis-je modifier ses caractéristiques de déplacement comme sa vitesse par exemple? Et enfin, quel est le nom du NavMesh permettant de faire le lien entre l'IA de mon personnage et le Level? 

Une autre question qui pourrait être pertinente est, est ce qu'il y a un lien direct entre notre FSM et le jeu? Est'il possible de coder à l'intérieur comme unreal le permet avec son AnimBlueprint ou est ce impossible comme dans unity et son animator? 

Y a t'il besoin d'avoir une entité supérieure à notre Character qui le contrôle comme l'AIController dans unreal?

Enfin, existe t'il un moyen de faire une transition "smooth" entre deux animations, grâce à un blendSpace comme dans unreal? 