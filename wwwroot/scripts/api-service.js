export class ApiService {

    static loadArticles(successFunction) {
        ApiService.makeGetRequest("article", successFunction)
    }

    static addUser(userName, userSurname, userEmail, userPassword, successFunction) {
        ApiService.makePostRequest(`User`, { name: userName, surname: userSurname, email: userEmail, password: userPassword }, successFunction)
    }

    static addArticle(articleTitle, articleText, successFunction) {
        ApiService.makePostRequest(`Article`, { title: articleTitle, text: articleText }, successFunction)
    }

    static makeGetRequest(requestUrl, successFunction) {
        $.ajax({
            method: "GET",
            url: requestUrl,
        }).done(successFunction);
    }

    static makePostRequest(requestUrl, data, successFunction) {
        $.ajax({
            method: "POST",
            contentType: "application/json",
            url: requestUrl,
            data: JSON.stringify(data)
        }).done(successFunction);
    }
}