var listbox;
var filterTextBox;

function pageLoad() {
    listbox = $find("<%= lstMarcasSource.ClientID %>");
    filterTextBox = document.getElementById("<%= TextBox1.ClientID %>");
    // set on anything but text box
    listbox._getGroupElement().focus();
}

function OnClientDroppedHandler(sender, eventArgs) {
    // clear emphasis from matching characters
    eventArgs.get_sourceItem().set_text(clearTextEmphasis(eventArgs.get_sourceItem().get_text()));
}

function filterList() {
    clearListEmphasis();
    createMatchingList();
}

// clear emphasis from matching characters for entire list
function clearListEmphasis() {
    var re = new RegExp("</{0,1}em>", "gi");
    var items = listbox.get_items();
    var itemText;

    items.forEach
    (
        function (item) {
            itemText = item.get_text();
            item.set_text(clearTextEmphasis(itemText));
        }
    )
}

// clear emphasis from matching characters for given text
function clearTextEmphasis(text) {
    var re = new RegExp("</{0,1}em>", "gi");
    return text.replace(re, "");
}

// hide listboxitems without matching characters
function createMatchingList() {
    var items = listbox.get_items();
    var filterText = filterTextBox.value;
    var re = new RegExp(filterText, "i");

    items.forEach
    (
        function (item) {
            var itemText = item.get_text();

            if (itemText.toLowerCase().indexOf(filterText.toLowerCase()) != -1) {
                item.set_text(itemText.replace(re, "<em>" + itemText.match(re) + "</em>"));
                item.set_visible(true);
            }
            else {
                item.set_visible(false);
            }
        }
    )
}