import { ApiService } from "./api-service.js";

let articleCardTemplate = document.getElementById("article-card-template");
let articleCardsContainer = document.getElementById("articles-list-container");

function reloadArticlesList() {
    let articleCards = [];

    ApiService.loadArticles((response) => {

        for (let article of response) {
            let card = articleCardTemplate.innerHTML;

            card = card.replaceAll("{title}", article.title);
            card = card.replaceAll("{text}", article.text);
            //card = card.replaceAll("{articleId}", article.id);

            card = `<div class="article-card">${card}</div>>`

            articleCards.push(card);
        }

        articleCardsContainer.innerHTML = articleCards.join();
    });
}

function replace_publish() {
    window.location.replace("https://localhost:7187/public.html")
}

function addUser() {
    const userName = $("#username-input").val();
    const userSurname = $("#surname-input").val();
    const userEmail = $("#email-input").val();
    const userPassword = $("#password-input").val();

    ApiService.addUser(userName, userSurname, userEmail, userPassword, replace_publish)
}

function replace_create_article(){
    window.location.replace("https://localhost:7187/create_article.html")
}
function replace_read(){
    window.location.replace("https://localhost:7187/read.html")
}

function replace_read_article(){
    window.location.replace("https://localhost:7187/read_article.html");
}

function addArticle() {
    const articleTitle = $("#title-input").val();
    const articleText = $("#text-input").val();

    ApiService.addArticle(articleTitle, articleText, replace_publish)
}

window.addUser = addUser;
window.addArticle = addArticle;
window.replace_create_article = replace_create_article;
window.replace_read = replace_read;
window.replace_publish = replace_publish;
window.reloadArticlesList = reloadArticlesList;
window.replace_read_article = replace_read_article;