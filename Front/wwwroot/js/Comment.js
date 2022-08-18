
//var wishList = document.querySelector("btnc")
//function DisplayLike(roomId) {
//    var element = document.querySelector(".index(6)");
//    console.log(element);
//    element.classList.toggle("mystyle");
//}
$(document).ready(function () {


   
        $(".Save").click(function () {
            window.location.reload();
           
            });


        $(".Delete").click(function () {
            window.location.reload();
        });
    });
 

function InsertComment(roomId,index,orderid) {
    console.log(roomId);

    const webapiUrl = "/api/CommentApi/";



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

function DeleteComment(roomid,orderId) {
    console.log(orderId);
    const webapiUrl = "/api/CommentApi/";


    let request = new Request(webapiUrl + "Delete", {
        method: "DELETE",
        headers: {
            "content-type": "application/json; charset=UTF-8"
        },
        body: JSON.stringify({
            RoomId: roomid,
            Orderid: "" + orderId,
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
        });

}

