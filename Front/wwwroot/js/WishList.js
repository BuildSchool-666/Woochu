
//var wishList = document.querySelector("btnc")
//function DisplayLike(roomId) {
//    var element = document.querySelector(".index(6)");
//    console.log(element);
//    element.classList.toggle("mystyle");
//}



function InsertWishList(roomId) {
    console.log(roomId);
    var element = document.querySelector(`.index_${roomId}`);
    var a = $(`.index_${roomId}`).attr("data-prefix")
    console.log(element);
    console.log(a);


    const webapiUrl = "/api/WishListAPI/";

    if (a == "fas") {
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
                    $(`.index_${roomId}`).attr("data-prefix", "far");
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
                    $(`.index_${roomId}`).attr("data-prefix", "fas");
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