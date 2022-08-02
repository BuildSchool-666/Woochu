
//var wishList = document.querySelector("btnc")
//function DisplayLike(roomId) {
//    var element = document.querySelector(".index(6)");
//    console.log(element);
//    element.classList.toggle("mystyle");
//}


function InsertWishList(roomId) {
    console.log(roomId);
    var element = document.querySelector(`.index_${roomId}`);
    var a = document.querySelector('.fa-heart')
    console.log(a)
    console.log(element);

    const webapiUrl = "/api/WishList/";

    if (element.classList.contains("fas")) {
        let request = new Request(webapiUrl + "Delete", {
            method: "DELETE",
            headers: {
                "content-type": "application/json; charset=UTF-8"
            },
            body: JSON.stringify(roomId)
        });
        fetch(request)
            .then(response => {
                if (response.ok) {
                    element.classList.toggle("fas");
                    return response.text();
                }
                else {
                    throw new Error(`發生錯誤:${response.status},${response.statusText}`);
                }
            });
    }
    else {
        let request = new Request(webapiUrl + "Create", {
            method: "POST",
            headers: {
                "content-type": "application/json; charset=UTF-8"
            },
            body: JSON.stringify(roomId)
        });
        fetch(request)
            .then(response => {
                if (response.ok) {
                    element.classList.toggle("fas");
                    return response.text();
                }
                else {
                    throw new Error(`發生錯誤:${response.status},${response.statusText}`);
                }
        })
    }

    


    
        //.then(result => { msg.innerText = result; })
        //.catch(ex => { msg.innerText = ex; });
}