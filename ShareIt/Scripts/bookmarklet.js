if (!($ = window.jQuery)) { // typeof jQuery=='undefined' works too
    script = document.createElement('script');
    script.src = 'http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js';
    script.onload = releasetheKraken;
    document.body.appendChild(script);
}
else {
    releasetheKraken();
}

function releasetheKraken() {

    var data = { 
        Title: document.title,
        Url: window.location.href
    };

    console.dir(data);

    $.ajax({
        type: "PUT",
        url: "http://shareit.apphb.com/api/feeds/" + window.sharemeFeedId,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: function () { alert("added...");},
    });
}