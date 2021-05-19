<template>
  <div class="ms-select-autocomplete">
    <div v-if="label" class="flex">
      <div class="ms-input-title">
        <div class="ms-input-title-label">{{ label }}</div>
      </div>
      <div v-if="required" class="ms-input-title-require">&nbsp;*</div>
    </div>
    <v-autocomplete
      class="border-radius-2"
      :items="items"
      outlined
      allow-overflow
      auto-select-first
      no-data-text="Không có dữ liệu hiển thị."
      :placeholder="placeholder"
      :value="items[itemDefault]"
      color="#2ca01c"
      :menu-props="{ offsetOverflow: true, offsetY: true }"
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
      <template v-slot:item="data">
        <template>
          <v-list-item-content
            v-text="data.item"
            :title="data.item"
          ></v-list-item-content>
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
    readonly: {
      type: Boolean,
      default: false,
    },
    required: {
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
    hasAddButton: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {};
  },
  methods: {},
  mounted() {},
};
</script>
<style scoped>
.ms-select-autocomplete {
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

.ms-select-autocomplete .ms-input-title {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  white-space: nowrap;
}

.ms-select-autocomplete .ms-input-title-label {
  height: 100%;
}

.ms-select-autocomplete .ms-input-title-require {
  color: red;
  margin-left: 4px;
}
</style>
<style>
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

.menu-select-autocomplete-menu.v-menu__content {
  border: 1px solid #babec5;
  border-radius: 2px;
  z-index: 10000 !important;
  max-height: 256px;
}

.v-list.v-select-list {
  padding: 2px 0;
}

.ms-select-autocomplete .v-text-field .v-input__append-inner {
  margin-top: 0px;
  /* margin-bottom: 5px; */
  cursor: pointer;
  height: 100%;
  border-bottom-right-radius: 2px;
  border-top-right-radius: 2px;
}

.v-input__append-inner .v-input__icon.v-input__icon--append {
  height: unset;
}

/* .ms-select-autocomplete .v-input__append-inner:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
} */

fieldset {
  z-index: 1;
}

.ms-select-autocomplete .v-text-field--outlined fieldset{
  top: -6px;
}

.ms-select-autocomplete .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state):not(.v-input--is-disabled)>.v-input__control>.v-input__slot:hover fieldset {
    color: rgba(0, 0, 0, .38) !important;;
}

.ms-select-autocomplete .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state):not(.v-input--is-disabled)>.v-input__control>.v-input__slot:hover{
    outline: 1px solid #e2e2e2 !important;
}

.ms-select-autocomplete .v-text-field .v-input__append-inner {
  padding-right: 0;
}

.ms-select-autocomplete .v-text-field .v-input__append-inner {
  margin-top: 0;
  cursor: pointer;
  height: 100%;
  border-bottom-right-radius: 2px;
  border-top-right-radius: 2px;
}

.ms-select-autocomplete
  .v-text-field
  .v-input__append-inner
  .v-input__icon.v-input__icon--append,
.ms-select-autocomplete .v-text-field .v-input__append-inner .btn-add {
  width: 32px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.ms-select-autocomplete
  .v-text-field
  .v-input__append-inner
  .v-input__icon.v-input__icon--append:hover,
.ms-select-autocomplete
  .v-text-field
  .v-input__append-inner
  .btn-add:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

.ms-select-autocomplete .v-text-field .v-input__append-inner .btn-add {
  border-right: 1px solid #babec5;
}
</style>
