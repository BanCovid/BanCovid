
export const moneyFormat = (num: number) => {
    if (!num) num = 0;
    return 'RD $' + num.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

export const dateShortFormat = (date: Date) => {
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();
    if (month < 10) {
        return `${day}-0${month}-${year}`;
    } else {
        return `${day}-${month}-${year}`;
    }
}
