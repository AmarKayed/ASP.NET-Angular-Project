(The following text is in Romanian)

# Barem

Intai avem cerintele proiectului, dupa care avem unde se regasesc mai exact aceste cerinte completate in acest proiect.

```
Salut, va trimit inca o data cerintele, nu s a schimbat nimic dar am pus si punctaju la fiecare cerinta. Reamintesc ca nota este 8p proiectul, 2p prezenta si 1p Bonus pentru functionalitati extra.

1. Aceasta este lista finala de cerinte pt Frontend (4p)
Orice numar se specifica in cerinte se inmulteste cu numarul de coechipieri
Ex. Cerinta 1 cere cel putin 3 componente. Daca sunteti 2 in echipa => 6 componente. Daca sunteti 3 => 9 componente.
 -Cel putin 3 componente. Existenta rutelor(simple + parametru). (0.5 p)
 -Cel putin 3 servicii conectate la serverul din .Net . Afisarea de date din servicii in componente. (1p)
 -Cel putin 2 formulare. (Reactive forms) - inafara de login/register (0.5 p)
 -Implementarea metodelor de comunicare intre componente. (neaparat sa fie folosita macar 1 data comunicarea printr-un serviciu) (0.5p)
 -Cel putin 1 directiva. (pe langa cea facuta la laborator) (0.25)
 -Cel putin 1 pipe 0.25
 -Register + Login + Implementare Guard (1p)


2. Backend (4p) :
Aceeasi regula, orice numar se specifica in cerinte se inmulteste cu numarul de coechipieri 
 -3 Controllere (minim); Fiecare Metoda Crud, REST cu date din baza de date. (1p)
 -Cel puțin 1 relație între tabele din fiecare fel (One to One, Many to Many, One to Many); Folosirea metodelor din Linq: GroupBy, Where, etc; Folosirea Join si Include (1p)
 -Autentificare + Roluri; Autorizare pe endpointuri în funcție de Roluri; Cel putin 2 Roluri: Admin, User (1p)
 -Sa se foloseasca repository pattern/unit of work (1p)
 
 
3. Prezente (2p) 
 Am avut 9 laboratoare in total care au contat la prezenta deci 1 prezenta valoreaza 0.23 p
 
4. Bonus Functionalitati Extra de exemplu: integrare Facebook, trimitere de mailuri etc. (1p)
Orice mai e ambiguu, dati mi mesaj 
```

> Cerinte existente in acest proiect sunt dupa cum urmeaza:

### Frontend
* Minim 3 Componente:
    Module(se gasesc in folderul frontend/src/app/modules)
    1. app.module.ts(acesta este global), 
    2. login.module.ts
    3. profile.module.ts

    Componente:
    1. login.component.ts
    1. profile.component.ts
    1. deadline.component.ts
    1. add-deadline.component.ts
    1. update-address.component.ts

* Rute:
    Se gasesc in 
    1. app-routing.module.ts
    1. login.routes.ts + auth.guard.ts
    1. profile.routes.ts
    Rutele site-ului:
    '' se redirectioneaza catre /login
    Ruta simpla: /login
    Ruta cu parametru: /profile/:email
    /profile este o ruta privata, daca nu suntem autentificati atunci nu avem voie sa accesam aceasta pagina si vom fi redirectionati inapoi catre /login, acest lucru este implementat prin auth.guard.ts

* Minim 3 Servicii contectate la .Net + Afisare Date din Servicii:
    Servicii(se gasesc in folderul frontend/src/app/services)
    In auth.service.ts avem serviciile de Auth + Register
    In profile.service.ts avem GET student, address, deadline; POST deadline, PUT address.

    Din fiecare endpoint de GET se afiseaza datele in pagina de profil.

* 2 formulare in afara de login/register:
    * Formularele se gasesc in componentele add-deadline.component.html + update-address.component.html
    * add-deadline apeleaza POST deadline
    * update-address apeleaza PUT address

* Metodelor de comunicare intre componente. (neaparat sa fie folosita macar 1 data comunicarea printr-un serviciu)
    * Se poate intalni de mai multe ori decoratorul @Input(), nu exista si decoratorul @Output() impreuna cu un eventEmitter, intrucat nu am gasit un caz in care sa il folosesc in cadrul aplicatiei.
    * Exista si comunicarea realizata prin BahaviorSubject, se gaseste in fisierele profile.service.ts + profile.component.ts si este folosita de componentele profile + update-address prin intermediul serviciului profile.service.ts

* Cel putin 1 directiva
    * Directivele folosite sunt: 
        * ngIf  (login.component.html + profile.component.html)
        * ngFor  (profile.component.html)
        * ngClass  (login.component.html)

* Cel putin 1 pipe 0.25
    * Pipe-urile folosite au fost titlecase + uppercase in login.component.html
* Register + Login + Implementare Guard
    * Login si Register sunt implementate in cadrul aceleasi pagini(rute), folosind ngIf pentru a le diferentia/separa
    * Serviciul de apelare a serviciilor .Net pentru Login + Register se gasesc in auth.service.ts
    * Implementarea Guard se gaseste in auth.guard.ts
    * Guard-ul implementat nu permite accesul la pagina de profil fara ca utilizatorul sa fie logat




### Backend
> Exista **5 entitati** pe partea de backend, 4 daca excludem entitatea asociativa StudentTeacher.
* 3 Controllere (minim); Fiecare Metoda Crud, REST cu date din baza de date. (1p)
    * Exista 4 controllere, fiecare pentru cele 4 entitati neasociative. Fiecare controller implementeaza minim toate metodele CRUD
    * Exista o conexiune la o baza de date locala facuta in SSMS, baza de date se numeste student-platform
    * Exista, de asemenea, un script de inserari de date initiale in baza de date, acesta insa nu mai este actual 100%, intrucat a fost facut inainte de implementarea serviciul de autentificare.

* Cel puțin 1 relație între tabele din fiecare fel (One to One, Many to Many, One to Many); Folosirea metodelor din Linq: GroupBy, Where, etc; Folosirea Join si Include (1p)
    * Relatiile bazei de date se pot regasi si in diagrama E/R din repository-ul de pe GitHub.
    * Relatiile sunt:
        * Student one-to-one Address
        * Student one-to-many Deadline
        * Student many-to-many Teacher(aceasta relatie se rezolva prin intermediul tabelei asociative StudentTeacher)
    * Metodele Linq se regasesc in mare parte in proiectul student-platform.DAL la StudentRepository.cs, insa se pot regasi si in celalalte repository-uri.

* Autentificare + Roluri; Autorizare pe endpointuri în funcție de Roluri; Cel putin 2 Roluri: Admin, User (1p)
    * Autentificarea a fost implementata cu succes, se pot gasi toate componentele unei autentificare JWT in folderul de backend
    * Autorizarea pe endpoint-uri s-a realizat in TeachersController.cs
    * Roluri: Admin + Student(care practic este un User in contextul nostru)
* Sa se foloseasca repository pattern/unit of work (1p)
    * Proiectul de backend este structurat pe 3 layere: API Controllers + Business Logic Layer + Data Access Layer
    * In folderul student-platform avem proiectul de Web API, unde gasim toate controllere + endpoint-uri
    * In folderul student-platform.BLL avem toti managerii + logica aplicatiei + logica autentificarii
    * In folderul student-platform.DAL avem toate entitatile + configuratiile + repository-urile + modelele pentru entitatile noastre
        * Fiecare clasa are si propria interfata asociata
        * Flow-ul proiectului este urmatorul: Se primeste un request intr-un endpoint dintr-un controller, se apeleaza o metoda din BLL, metoda din BLL cere la randul ei datele din DAL, DAL face conexiunea cu baza de date, cere datele insa nu le trimite asa cum sunt, in schimb trimite un model ce contine strict datele ce trebuie sa apara la client(fara chei primare, externe, obiecte virtuale, relatii, etc), BLL-ul primeste modelul, il prelucreaza in functie de logica aplicatiei, il intoarce la controller care in functie de rezultat trimite raspunsul final al request-ului impreuna cu rezultatul, dupa caz.

### Prezente
Am fost prezent la toate cele 5 laboratoare de ASP.NET + 3 laboratoare Angular, laboratorul 8 nu s-a tinut, intrucat a picat pe 1 decembrie, iar ultimele 2 laboratoare erau cu prezenta optionala, intrucat erau doar pentru intrebari legate de proiect.

### Functionalitati Extra
Proiectul nu are functionatlitati extra precum autentificare prin facebook sau serviciu de mail.
