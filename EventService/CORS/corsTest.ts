type HttpMethod = "GET" | "POST" | "PUT" | "DELETE";

function serviceCall<Tin, Tout>(method: HttpMethod, endpoint: string, sendData: Tin, success: (v: Tout) => void, fail?: (status: number) => void) {
    const xhr = new XMLHttpRequest();
    const url = endpoint.indexOf("http") === 0 ? endpoint : `${this.apiEndPoint}/${endpoint}`;
    xhr.open(method, url, true);
    xhr.setRequestHeader("Content-Type", "application/json");

    if (url.indexOf("trumba.com") !== -1) {
        xhr.setRequestHeader(".THUNDERAUTH10",
            "C7742EAFFA4BE2847560F10662E7B76F80E70A1A773059E64DE67142B434BE00484F688FF88C12381E7D3B791E545721138ACC11E8434013ADF5931E695C8C746A529E7F917B07BA5A47CF0A8191E0D12C8E7A8BCD4553A63189EE81A5C649853F449833CC8C337462F845BE8A1E21FB2D098F9B3959BAB316A3D7033632FCB34FE841DF2D89C37CE434A81BDF52212405AA1154");
    }

    xhr.onload = () => {
        if (xhr.status === 200) {
            success(JSON.parse(xhr.responseText) as Tout);
        }
        else if (fail) {
            fail(xhr.status);
        }
    };

    xhr.send(sendData ? JSON.stringify(sendData) : null);
}

function getNewEventModel(calId: number, success: (ts: any) => void, fail?: (status: number) => void): void {
    serviceCall<null, any>("GET", `https://www.qatrumba.com/api/t2/model?calendarid=${calId}`, null, success, fail);
}

getNewEventModel(35,
    (m) => {
        document.getElementById("output").textContent = JSON.stringify(m, null, "\t");
    },
    (status) => {
        document.getElementById("output").textContent = `Call failed with status code ${status}`;
    }
);
