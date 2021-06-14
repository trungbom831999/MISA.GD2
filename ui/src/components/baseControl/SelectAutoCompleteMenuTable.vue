<template>
  <div class="ms-select-autocomplete-menu">
    <div v-if="label" class="label-input">{{ label }}</div>
    <v-autocomplete
      class="border-radius-2"
      v-model="temporaryList"
      v-bind:value="value"
      v-on:input="$emit('input', temporaryList)"
      :disabled="isUpdating"
      :items="items"
      :chips="chip"
      :deletable-chips="chip"
      :item-text="mainItem"
      :item-value="valueItem ? valueItem : mainItem"
      :itemDefault="itemDefault"
      :menu-props="{
        offsetOverflow: true,
        allowOverflow: true,
        offsetY: true,
        contentClass: 'menu-select-autocomplete-menu',
      }"
      outlined
      allow-overflow
      auto-select-first
      no-data-text="Không có dữ liệu hiển thị."
      :placeholder="placeholder"
      color="#2ca01c"
      :multiple="multiple"
      @focus="setHeaderOfListBox()"
      :readonly="readonly"
    >
      <template v-if="hasAddButton" v-slot:append>
        <button class="btn-add">
          <div class="mi mi-16 mi-plus--success"></div>
        </button>
        <div class="v-input__icon v-input__icon--append">
          <i
            aria-hidden="true"
            class="v-icon notranslate mdi mdi-menu-down theme--light"
          ></i>
        </div>
      </template>
      <template v-if="chip" v-slot:selection="data">
        <v-chip
          v-bind="data.attrs"
          :input-value="data.selected"
          close
          @click="data.select"
          @click:close="readonly? '' : remove(data.item)"
          :title="data.item[mainItem]"
        >
          {{ data.item[mainItem] }}
        </v-chip>
      </template>
      <template v-slot:item="data">
        <template v-if="typeof data.item !== 'object'">
          <v-list-item-content v-text="data.item"></v-list-item-content>
        </template>
        <template v-else>
          <div class="menu-table-row">
            <div
              v-for="(cell, k, i) in data.item"
              v-bind:key="k"
              class="menu-table-item"
              v-bind:title="data.item[k]"
              v-bind:class="'w-' + column[i].width"
              v-bind:style="[
                { 'min-width': column[i].width + 'px' },
                { 'max-width': column[i].width + 'px' },
              ]"
              style="text-align: left"
            >
              {{ data.item[k] }}
            </div>
            <div class="selected-container">
              <div class="selected"></div>
            </div>
          </div>
        </template>
      </template>
    </v-autocomplete>
  </div>
</template>
<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    column: {
      type: Array,
      default() {
        return [];
      },
    },
    items: {
      type: Array,
      default() {
        return [];
      },
    },
    mainItem: {
      type: String,
      default: "",
    },
    valueItem: {
      type: String,
      default: "",
    },
    itemDefault: {
      type: String,
      default: null,
    },
    readonly: {
      type: Boolean,
      default: false,
    },
    placeholder: {
      type: String,
      default: "",
    },
    chip: {
      type: Boolean,
      default: false,
    },
    multiple: {
      type: Boolean,
      default: false,
    },
    hasAddButton: {
      type: Boolean,
      default: false,
    },
    value: {},
  },
  data() {
    return {
      autoUpdate: true,
      temporaryList: [],
      isUpdating: false,
      name: "Midnight Crew",
      col: this.column,
      suppliers: [
        // { name: "column", col: ["gr1", "gr2"], disabled: true },
        {
          name: "Sandra Adams",
          group: "Group 1",
        },
        { name: "Ali Connors", group: "Group 1" },
        {
          name: "Trevor Hansen Trevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor HansenTrevor Hansen",
          group: "Group 1",
        },
        {
          name: "Tucker Smith",
          group: "Group 1",
        },
        { name: "Britta Holt", group: "Group 2" },
        { name: "Jane Smith ", group: "Group 2" },
        { name: "John Smith", group: "Group 2" },
        { name: "Sandra Williams", group: "Group 2" },
      ],
    };
  },
  watch: {
    value() {
      this.temporaryList = this.value;
    },
    valueItem() {
      if (!this.valueItem) {
        this.valueItem = this.mainItem;
      }
    },
  },
  methods: {
    remove(item) {
      const index = this.temporaryList.indexOf(item[this.valueItem]);
      if (index >= 0) this.temporaryList.splice(index, 1);
    },
    setHeaderOfListBox() {
      // console.log(this.column);
      var cols = this.column;
      setTimeout(function () {
        var idListBox = document.getElementsByClassName(
          "menuable__content__active"
        )[0].children[0].id;
        var header = "<div class='header-menu-select-autocomplete-menu'>";
        for (var i = 0; i < cols.length; i++) {
          header += `<div title="${cols[i].name}" class="menu-header__th w-${cols[i].width}" style="width: ${cols[i].width}px; text-align: left">
            <span>${cols[i].name}</span>
          </div>`;
        }
        header += "</div>";
        var listBox = document.getElementById(idListBox);
        // listBox.insertBefore(header, listBox.childNodes[0]);
        listBox.insertAdjacentHTML("beforebegin", header);
        console.log(idListBox);
      }, 50);
    },

    setDefaultItem() {
      if (this.itemDefault != null) {
        //console.log(this.items[this.itemDefault][this.mainItem]);
        if (this.multiple) {
          this.temporaryList.push(this.items[this.itemDefault][this.mainItem]);
        } else {
          this.temporaryList = this.items[this.itemDefault][this.mainItem];
        }
      }
    },

    //kiểm tra phần tử có trong mảng hay không
    checkIsInItems(item) {
      if (!this.valueItem) {
        this.valueItem = this.mainItem;
      }
      for (let i in this.items) {
        if (item == i[this.valueItem]) {
          console.log("có");
          return true;
        }
      }
      return false;
    },
  },
  created() {},
  mounted() {
    this.setDefaultItem();
    this.temporaryList = this.value;
  },
};
</script>
<style scoped>
.ms-select-autocomplete-menu {
  width: 100%;
  height: 100%;
  position: relative;
  display: flex;
  flex-direction: column;
  margin: 0;
}

.label-input {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  color: #111;
}
</style>
<style>
.ms-select-autocomplete-menu
  .v-select.v-text-field--outlined:not(.v-text-field--single-line)
  .v-select__selections {
  /*padding: 6px 0;*/
}

/*css chips */
.v-chip.v-size--default {
  border-radius: 3px;
  font-size: inherit;
  height: unset;
}

.v-select .v-chip {
  flex: 0 1 auto;
  margin: 3px;
  margin-right: 2px;
}

.ms-select-autocomplete-menu .v-chip {
  padding: 2px 8px;
  text-overflow: ellipsis;
}

.v-select.v-select--chips:not(.v-text-field--single-line).v-text-field--enclosed
  .v-select__selections {
  min-height: 32px;
}

.ms-select-autocomplete-menu
  .v-autocomplete.v-input
  > .v-input__control
  > .v-input__slot {
  background-color: #fff;
}

.ms-select-autocomplete-menu .v-text-field--outlined fieldset {
  bottom: 0px;
  top: -5.5px;
}

.ms-select-autocomplete-menu .theme--light.v-chip:not(.v-chip--active) {
  border: 1px solid #ccc;
  background-color: #f0f0f0;
}

.ms-select-autocomplete-menu
  .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state):not(.v-input--is-disabled)
  > .v-input__control
  > .v-input__slot:hover
  fieldset {
  border: 1px solid #babec5;
}

.ms-select-autocomplete-menu
  .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state)
  > .v-input__control
  > .v-input__slot
  fieldset {
  color: #babec5;
  border: 1px solid #babec5;
}

.ms-select-autocomplete-menu .v-chip .v-chip__content {
  max-width: 96%;
  padding-right: 12px;
  flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.ms-select-autocomplete-menu .v-chip .v-chip__content button {
  color: #f0f0f0;
  background-color: #000;
  border-radius: 50%;
  height: 12px;
  width: 12px;
  position: absolute;
  right: 8px;
}

.ms-select-autocomplete-menu .theme--light.v-chip:hover:before {
  opacity: 0;
}

.ms-select-autocomplete-menu .v-text-field .v-input__append-inner {
  padding-right: 0;
}

.ms-select-autocomplete-menu .v-text-field .v-input__append-inner {
  margin-top: 0;
  cursor: pointer;
  height: 100%;
  border-bottom-right-radius: 2px;
  border-top-right-radius: 2px;
}

.ms-select-autocomplete-menu
  .v-text-field
  .v-input__append-inner
  .v-input__icon.v-input__icon--append,
.ms-select-autocomplete-menu .v-text-field .v-input__append-inner .btn-add {
  width: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.ms-select-autocomplete-menu
  .v-text-field
  .v-input__append-inner
  .v-input__icon.v-input__icon--append:hover,
.ms-select-autocomplete-menu
  .v-text-field
  .v-input__append-inner
  .btn-add:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

.ms-select-autocomplete-menu .v-text-field .v-input__append-inner .btn-add {
  border-right: 1px solid #babec5;
}

.menu-select-autocomplete-menu {
  transition: opacity 0.1s, transform 0.1s, width 0.2s ease;
  margin: 0 !important;
}
.menu-select-autocomplete-menu .menu-header__th {
  padding: 0 10px;
  height: 32px;
  color: #111;
  background: #f4f5f8;
  border-collapse: collapse;
}

.menu-select-autocomplete-menu .menu-header__th {
  padding: 0 10px;
  height: 32px;
  color: #111;
  background: #f4f5f8;
  border-collapse: collapse;
  display: flex;
  place-items: center;
}

.menu-select-autocomplete-menu .v-list-item {
  padding: 0;
}

.menu-select-autocomplete-menu .header-menu-select-autocomplete-menu {
  color: #111;
  background: #f4f5f8;
  align-items: center;
  display: flex;
  flex: 1 1 100%;
  letter-spacing: normal;
  min-height: 32px;
  outline: none;
  position: sticky;
  top: 0;
  z-index: 1;
  text-decoration: none;
  font-size: 0.85rem;
  font-weight: 600;
}

.menu-select-autocomplete-menu .menu-table-row {
  display: flex;
  align-items: center;
  cursor: pointer;
  height: 32px;
  line-height: 32px;
  white-space: nowrap;
}

.menu-select-autocomplete-menu .menu-table-item {
  padding: 0 10px;
  flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.selected-container {
  width: 36px;
  height: 20px;
}

.selected-container .selected {
  padding-right: 10px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
  background-position: -896px -312px;
  width: 16px;
  height: 16px;
  display: none;
}

.menu-select-autocomplete-menu .v-list-item--active .menu-table-item {
  color: #fff;
}

.ms-select-autocomplete-menu .v-select__selection--comma {
  margin: 0;
}
</style>