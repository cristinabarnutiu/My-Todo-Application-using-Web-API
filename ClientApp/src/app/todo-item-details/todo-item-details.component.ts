import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-todo-item-details',
  templateUrl: './todo-item-details.component.html',
  styleUrls: ['./todo-item-details.component.css']
})
export class TodoItemDetailsComponent implements OnInit {

    private todoItem: TodoItemWithDetails;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL')
        private baseUrl: string,
        //@Input() private todoItemId: number
        private route: ActivatedRoute){

        //this.loadTodoItem();
    }

    loadTodoItem(todoItemId: string) {
        this.http.get<TodoItemWithDetails>(this.baseUrl + 'api/todoitems/'+todoItemId).subscribe(result => {
            this.todoItem = result;
            console.log(this.todoItem);
        }, error => console.error(error));
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.loadTodoItem(params.get('todoItemId'));
        });
  }

}

interface Comment {
    id: number;
    text: string,
    important: boolean
}

interface TodoItemWithDetails {
    id: number;
    title: string;
    description: string;
    dateAdded: Date;
    deadline: Date;
    importance: string;
    state: string;
    dateClosed: Date;
    comments: Comment[]
}
