
//var wishList = document.querySelector("btnc")
//function DisplayLike(roomId) {
//    var element = document.querySelector(".index(6)");
//    console.log(element);
//    element.classList.toggle("mystyle");
//}
$(document).ready(function () {

    var classList = $('.Save').attr('value').split(/\s+/);

   
        $(".Save").click(function () {
            $(`.${classList[0]}`).css("display", "none");
            $(`.${classList[1]}`).css("display", "block");
            window.location.reload();
            parent.location.reload();
            opener.location.reload();
            top.location.reload();
            });


        $(".Delete").click(function () {
            $(`.${classList[0]}`).css("display", "block");
            $(`.${classList[1]}`).css("display", "none");
            window.location.reload();
            parent.location.reload();
            opener.location.reload();
            top.location.reload();
        });
    });
 

function InsertComment(roomId,index,orderid) {
    console.log(roomId);

    const webapiUrl = "/api/CommentApi/";


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
    
    let score = document.querySelector('input[name="inlineRadioOptions"]:checked').value;
    let text = $(`.text_${index}`).val();
    //var html = $("#validationServer01").val();
    console.log(text);

    
    let request = new Request(webapiUrl + "Create", {
        method: "POST",
        headers: {
            "content-type": "application/json; charset=UTF-8"
        },
        body: JSON.stringify({
            RoomId: roomId,
            Cleanliness: score,
            Accuracy : score,
            Communication : score,
            Location: score,
            CheckIn: score,
            CP: score,
            comment: text,
            OrderId: ""+orderid,



        })
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

function DeleteComment(roomId) {
    console.log(roomId);
    const webapiUrl = "/api/CommentApi/";


    let request = new Request(webapiUrl + "Delete", {
        method: "DELETE",
        headers: {
            "content-type": "application/json; charset=UTF-8"
        },
        body: JSON.stringify(
                roomId
        )
    });
    fetch(request)
        .then(response => {
            if (response.ok) {
                return response.text();
            }
            else {
                throw new Error(`發生錯誤:${response.status},${response.statusText}`);
            }
        });

}

