window.localStorageInterop = {
    writeJsonToFile: function (fileName, jsonData) {
        fetch(`/wwwroot/${fileName}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(jsonData)
        });
    }
};