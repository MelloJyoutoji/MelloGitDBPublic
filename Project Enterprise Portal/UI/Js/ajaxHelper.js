var ajax = {};
ajax.CellBack = function (type, url, dataBase, resultFunc) {
    var myAjax;//申明ajax对象
    if (window.ActiveXObject) {//IE内核浏览器
        myAjax = new ActiveXObject("Microsoft.XMLHTTP");
    } else if (window.XMLHttpRequest) { //谷歌,火狐内核浏览器
        myAjax = new XMLHttpRequest();
    } else {
        myAjax = new XMLHttpRequest("MSXML2.XMLHTTP4.0");
    }
    //2.打开服务器的连接以及给服务器发送请求
    myAjax.open(type, url);
    //清空缓存
    if (type == "get") {
        myAjax.setRequestHeader("If-Modified-Since", "0");
        myAjax.send(null);
    } else if (type == "post") {
        myAjax.setRequestHeader("content-type", "application/x-www-form-urlencoded");
        myAjax.send(dataBase);
    }
    //3.监听服务器响应的状态
    myAjax.onreadystatechange = function () {
        if (myAjax.readyState == 4) {//服务器响应为完成状态
            if (myAjax.status == 200) {//响应一切正常
                //获取服务器的返回数据
                var result = myAjax.responseText;
                resultFunc(result);
            }
        }
    }
};