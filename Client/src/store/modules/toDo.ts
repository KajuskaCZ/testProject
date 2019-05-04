import Vuex from 'vuex';
import Vue from 'vue';

export default {
    state: {
        toDos: []
    },
    getters: {
        allToDos(state, getters) {
            return state.toDos;
        },
        unCheckedToDos(state, getters) {
            return state.toDos.filter(toDos => toDos.check == false);
        },
        checkedToDos(state, getters) {
            return state.toDos.filter(toDos => toDos.check == true);
        }
    },
    actions: {
        fetchToDos(context) {
            Vue.http.get('http://localhost:8000/api/todo').then(
                response => {
                    context.commit('setToDos', response.body);
                },
                error => {
                    console.log("ERROR: ", error);
                }
            );
        },
        fetchSortToDos(context, isDescendingSort) {
            context.commit('sortToDos', isDescendingSort);
        }
    },
    mutations: {
        setToDos(state, toDos) {
            state.toDos = toDos;
        },
        sortToDos(state, isDescendingSort) {
            state.toDos.sort((item1, item2) => {
                if (item1.name > item2.name) {
                    return isDescendingSort ? -1 : 1;
                }
                if (item1.name < item2.name) {
                    return isDescendingSort ? 1 : -1;
                }
                return 0;
            });
        }
    }
}