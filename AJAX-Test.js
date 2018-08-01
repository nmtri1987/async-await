(function () {
    //var TestClass = { //model
    //    Id: "1",
    //    name: "Peter"
    //};

    //$.ajax({
    //    type: "Post",
    //    url: 'http://localhost:28883/api/Test1',//change to your api url
    //    data: JSON.stringify(TestClass),//pass json object to web api
    //    contentType: 'application/json',
    //    dataType: "json",
    //    success: function (result) {
    //        alert(JSON.stringify(result));
    //    }
    //});
    var begin1 = performance.now();
    var counter1 = 0;
    for (var i = 0; i < 10; i++)
    {
        console.log('Normal: ' + (i + 1));
        $.ajax({
            type: "GET",
            url: 'http://localhost:28883/api/Product',//change to your api url
            data: { id: 2, name: 'tringo' },//pass json object to web api
            contentType: 'application/json',
            dataType: "json",
            success: function (result) {
                counter1++;
                //alert(JSON.stringify(result));
                console.log('-> Normal: ' + JSON.stringify(result));
                if (counter1 == 10)
                {
                    var end1 = performance.now();
                    console.log("Done Normal took " + (end1 - begin1) + " milliseconds.");

                    var begin2 = performance.now();
                    var counter2 = 0;

                    for (var j = 0; j < 10; j++) {
                        console.log('Async: ' + (j + 1));
                        $.ajax({
                            type: "GET",
                            url: 'http://localhost:28883/api/ProductAsync',//change to your api url
                            data: { id: 2, name: 'tringo' },//pass json object to web api
                            contentType: 'application/json',
                            dataType: "json",
                            success: function (result) {
                                counter2++;
                                //alert(JSON.stringify(result));
                                console.log('-> Async: ' + JSON.stringify(result));
                                if (counter2 == 10) {
                                    var end2 = performance.now();
                                    console.log("Done Async took " + (end2 - begin2) + " milliseconds.");
                                }
                            }
                        });
                    }
                }
            }
        });
    }

    //var begin2 = performance.now();
    //var counter2 = 0;

    //for (var i = 0; i < 10; i++) {
    //    console.log('Async: ' + (i + 1));
    //    $.ajax({
    //        type: "GET",
    //        url: 'http://localhost:28883/api/ProductAsync/2',//change to your api url
    //        data: { id: 2 },//pass json object to web api
    //        contentType: 'application/json',
    //        dataType: "json",
    //        success: function (result) {
    //            counter2++;
    //            //alert(JSON.stringify(result));
    //            console.log('-> Async: ' + JSON.stringify(result));
    //            if (counter2 == 10) {
    //                var end2 = performance.now();
    //                console.log("Done Async took " + (end2 - begin2) + " milliseconds.");
    //            }
    //        }
    //    });
    //}

    
})();

