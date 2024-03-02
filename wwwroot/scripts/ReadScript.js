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

            card = `<div class="article-card">${card}</div>`

            articleCards.push(card);
        }

        articleCardsContainer.innerHTML = articleCards.join('');
    });
}

reloadArticlesList();