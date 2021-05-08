<template>
  <div class="ms-select">
    <div v-if="label" class="label-input">{{label}}</div>
    <v-select
      class="border-radius-2"
      :items="items"
      outlined
      allow-overflow
      auto-select-first
      no-data-text="Không có dữ liệu hiển thị."
      :placeholder="placeholder"
      :value="items[itemDefault]"
      color="#2ca01c"
      :readonly="readonly"
      :menu-props="{ offsetOverflow: true, offsetY: true }"
    >
      <template v-slot:item="data">
        <template>
          <v-list-item-content
            v-text="data.item"
            :title="data.item"
          ></v-list-item-content>
        </template>
      </template>
    </v-select>
  </div>
</template>
<style scoped>
.ms-select{
  width: 100%;
  height: 100%;
  position: relative;
  display: flex;
  flex-direction: column;
}

.label-input {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  color: #111;
}
</style>
<style>
.v-select__selection--comma {
    margin: 6px 4px 6px 0;
}

.v-select.v-text-field--outlined:not(.v-text-field--single-line) .v-select__selections {
    padding: 0;
}

.v-select.v-text-field:not(.v-text-field--single-line) input {
    width: 0;
}

.v-list .v-list-item--active {
  color: #fff !important;
  background-color: #2ca01c;
}

.v-list-item:hover:not(.v-list-item--active):not(.v-list-item--disabled) {
  color: #2ca01c !important;
}

.v-text-field.v-text-field--enclosed .v-text-field__details {
  display: none;
}

.v-text-field--outlined > .v-input__control > .v-input__slot {
  min-height: unset;
  margin: 0;
}

.v-select__slot input:hover {
  border: none;
}

.v-list .v-list-item--active .v-list-item__content {
  color: #fff;
}

.v-menu__content {
      border: 1px solid #babec5;
    border-radius: 2px;
  z-index: 10000 !important;
  max-height: 256px;
}

.v-list.v-select-list{
  padding: 2px 0;
}

.v-application--is-ltr .v-text-field .v-input__append-inner {
  margin-top: 1px;
  /* margin-bottom: 5px; */
  cursor: pointer;
  height: 99%;
  border-bottom-right-radius: 2px;
  border-top-right-radius: 2px;
}

.v-input__append-inner .v-input__icon.v-input__icon--append {
  height: unset;
}

.ms-select .v-input__append-inner:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

fieldset {
  z-index: 1;
}
</style>
<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    readonly: {
      type: Boolean,
      default: false,
    },
    items: {
      type: Array,
      default() {
        return [];
      },
    },
    itemDefault: {
      type: Number,
    },
    placeholder: {
      type: String,
      default: "",
    },
  },
  data() {
    return {};
  },
  methods: {
    setReadOnly() {
      if (this.readonly == true) {
        document
          .getElementsByClassName("v-select__slot")[0]
          .getElementsByTagName("input")[0]
          .setAttribute("readonly", "true");
      }
    },

    removeClassPrimaryText() {
      document
        .getElementsByClassName("v-list-item--active")[0]
        .classList.remove("primary--text");
    },
  },
  mounted() {
    // this.setReadOnly();
  },
};
</script>