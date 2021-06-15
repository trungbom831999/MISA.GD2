<template>
  <div class="ms-select">
    <div v-if="label" class="label-input">{{ label }}</div>
    <v-select
      class="border-radius-2"
      :items="items"
      outlined
      allow-overflow
      auto-select-first
      no-data-text="Không có dữ liệu hiển thị."
      :placeholder="placeholder"
      v-model="pageSize"
      v-bind:value="value"
      v-on:input="$emit('input', pageSize)"
      color="#2ca01c"
      :readonly="readonly"
      :disabled="disabled"
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
    disabled: {
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
    value:{}
  },
   watch:{
     value() {
      this.temporaryList = this.value;
    },
  },
  data() {
    return {
      pageSize: ""
    };
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

    setValue() {
      if (this.value) {
        for (let i = 0; i < this.items.length; i++) {
          if (this.value == this.items[i]) {
            this.pageSize = this.items[i];
            break;
          }
        }
      } else if (this.itemDefault) {
        this.pageSize = this.items[this.itemDefault];
      }
    },
  },
  mounted() {
    this.setValue();
  },
};
</script>

<style scoped>
.ms-select {
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
.ms-select .v-select__selection--comma {
  margin: 6px 4px 6px 0;
  font-size: 13px;
}

.v-select.v-text-field--outlined:not(.v-text-field--single-line)
  .v-select__selections {
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
  /* max-height: 256px; */
}

.v-list.v-select-list {
  padding: 2px 0;
}

.ms-select .v-text-field .v-input__append-inner {
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

.ms-select .v-input__append-inner:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

.ms-select .v-text-field--outlined fieldset {
  top: -6px;
}

fieldset {
  z-index: 1;
}

/**Css disable */
.ms-select .theme--light.v-select .v-select__selection--disabled {
  color: rgba(0, 0, 0, 0);
}

.ms-select .v-input--is-disabled:not(.v-input--is-readonly) {
  background-color: #eff0f2;
}

.ms-select
  .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state):not(.v-input--is-disabled)
  > .v-input__control
  > .v-input__slot:hover
  fieldset {
  color: rgba(0, 0, 0, 0.38) !important;
}

.ms-select
  .theme--light.v-text-field--outlined:not(.v-input--is-focused):not(.v-input--has-state):not(.v-input--is-disabled)
  > .v-input__control
  > .v-input__slot:hover {
  outline: 1px solid #e2e2e2 !important;
}
</style>