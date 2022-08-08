
//var wishList = document.querySelector("btnc")
//function DisplayLike(roomId) {
//    var element = document.querySelector(".index(6)");
//    console.log(element);
//    element.classList.toggle("mystyle");
//}


function InsertComment(roomId) {
    console.log(roomId);
    var element = document.querySelector(`.index_${roomId}`);
    console.log(element);

    const webapiUrl = "/api/CommentAPI/";


    //let request = new Request(webapiUrl + "Delete", {
    //    method: "DELETE",
    //    headers: {
    //        "content-type": "application/json; charset=UTF-8"
    //    },
    //    body: JSON.stringify(roomId)
    //});
    //fetch(request)
    //    .then(response => {
    //        if (response.ok) {
    //            return response.text();
    //        }
    //        else {
    //            throw new Error(`發生錯誤:${response.status},${response.statusText}`);
    //        }
    //    });


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
                return response.text();
            }
            else {
                throw new Error(`發生錯誤:${response.status},${response.statusText}`);
            }
    })


    


    
        //.then(result => { msg.innerText = result; })
        //.catch(ex => { msg.innerText = ex; });
}
